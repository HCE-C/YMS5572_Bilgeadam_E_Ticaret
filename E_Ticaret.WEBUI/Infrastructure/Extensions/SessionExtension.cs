using E_Ticaret.WEBUI.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace E_Ticaret.WEBUI.Infrastructure.Extensions
{
    public static class SessionExtension
    {
        public static void SetObject<T>(this ISession session,string key ,T item)
        {
            var serrializeObj = JsonConvert.SerializeObject(item);
            session.SetString(key, serrializeObj);
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var stringData = session.GetString(key);
            var obj = JsonConvert.DeserializeObject<T>(stringData);
            return obj;
        }
    }
}
