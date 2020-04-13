using System;
using System.Collections.Generic;
using System.Text;

namespace Sapa.BLL.Dtos
{
    public class BaseResponse<T>
    {
        public BaseResponse()
        {

        }

        public BaseResponse(T result)
        {
            Data = result;
        }

        public BaseResponse(Exception ex)
        {
            Success = false;
            ErrorText = ex.Message;
            StackTrace = ex.StackTrace;
            Data = default(T);
        }

        /// <summary>
		/// Успешное выполнение ответа
		/// </summary>
		public bool Success { get; set; } = true;

        /// <summary>
        /// Сообщение с ошибкой
        /// </summary>
        public string ErrorText { get; set; }

        /// <summary>
        /// StackTrace ошибки
        /// </summary>
        public string StackTrace { get; set; }

        public T Data { get; set; }
    }
}
