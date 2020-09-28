using Dapper;
using MessagingAPI.Models;
using MessagingAPI.Models.Configuration;
using MessagingAPI.Repository.Interface;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingAPI.Repository
{
    public class SQLRepository : IRepository
    {
        private readonly ConnectionStrings _connectionStrings;

        public SQLRepository(IOptions<ConnectionStrings> options)
        {
            _connectionStrings = options.Value;
        }

        public async Task Create(MessageDTO message)
        {
            var sqlQuery = "INSERT INTO Messages(Username, Subject, Message) VALUES(@Username, @Subject, @Message);";

            var parameter = new DynamicParameters();

            parameter.Add("@Username", message.Username, DbType.String);
            parameter.Add("@Subject", message.Subject, DbType.String);
            parameter.Add("@Message", message.Message, DbType.String);

            using (var connection = new SqlConnection(_connectionStrings.SQLDBConnectionString))
            {
                await connection.ExecuteAsync(sqlQuery, parameter);
            }
        }

        public async Task Delete(Guid messageId)
        {
            var sqlQuery = "DELETE FROM Messages WHERE MessageId = @MessageID;";

            var parameter = new DynamicParameters();

            parameter.Add("@MessageId", messageId, DbType.Guid);

            using (var connection = new SqlConnection(_connectionStrings.SQLDBConnectionString))
            {
                await connection.ExecuteAsync(sqlQuery, parameter);
            }
        }

        public async Task<MessageDTO> Get(Guid messageId)
        {
            var sqlQuery = "SELECT * FROM Messages WHERE MessageId = @MessageId;";

            var parameter = new DynamicParameters();

            parameter.Add("@MessageId", messageId, DbType.Guid);

            using (var connection = new SqlConnection(_connectionStrings.SQLDBConnectionString))
            {
                var orderDetails = await connection.QueryAsync<MessageDTO>(sqlQuery, parameter);

                return orderDetails.FirstOrDefault();
            }
        }

        public async Task<List<MessageDTO>> GetAll()
        {
            var sqlQuery = "SELECT * FROM Messages";

            using (var connection = new SqlConnection(_connectionStrings.SQLDBConnectionString))
            {
                var orderDetails = await connection.QueryAsync<MessageDTO>(sqlQuery);

                return orderDetails.ToList();
            }
        }

        public async Task Update(Guid messageId, MessageDTO message)
        {
            var sqlQuery = @"UPDATE Messages
	                            SET Username = @Username,
		                            Subject = @Subject,
		                            Message = @Message
                            WHERE MessageId = @MessageId;";

            var parameter = new DynamicParameters();

            parameter.Add("@MessageId", messageId, DbType.Guid);
            parameter.Add("@Username", message.Username, DbType.String);
            parameter.Add("@Subject", message.Subject, DbType.String);
            parameter.Add("@Message", message.Message, DbType.String);

            using (var connection = new SqlConnection(_connectionStrings.SQLDBConnectionString))
            {
                await connection.ExecuteAsync(sqlQuery, parameter);
            }
        }
    }
}