using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SI.Utility
{
    public class JsonUtility
    {
        public static object Serialize(JsonResponse response)
        {
            try
            {
                System.Web.Script.Serialization.JavaScriptSerializer jSearializer =
                             new System.Web.Script.Serialization.JavaScriptSerializer();

                jSearializer.MaxJsonLength = 500000000;

                return jSearializer.Serialize(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static Object DeSerialize(string json, Type ObjectType)
        {
            try
            {

                Object objDeserialized = Newtonsoft.Json.JsonConvert.DeserializeObject(json, ObjectType);

                return objDeserialized;
            }
            catch (Exception ex)
            {
                throw;
            }


        }


    }
}
