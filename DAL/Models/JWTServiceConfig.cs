using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class JWTServiceConfig
    {
        public class JwtSettings
        {
            //Har ingen aning vad secret innebär än
            public string Secret { get; set; }
            public TimeSpan TokenLifeTime { get; set; }
        }
    }
}
