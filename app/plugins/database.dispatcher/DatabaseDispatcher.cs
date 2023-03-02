using RabbitMQ.Client;

namespace database.dispatcher
{
    public class DataDispatcher : IDatabaseGateway
    {
        public byte[] GetData()
        {
            throw new NotImplementedException();
        }

        public void SendData(string data, string connection)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Брокер сообщений
    /// </summary>
    public interface IDatabaseGateway
    {
        /// <summary>
        /// Отправить данные в базу данных социальной сети
        /// </summary>
        /// <param name="data"></param>
        public void SendData(string data, string connection);

        /// <summary>
        /// Получить данные из базы данных социальной сети
        /// </summary>
        /// <returns>Данные</returns>
        public byte[] GetData();
    }
}