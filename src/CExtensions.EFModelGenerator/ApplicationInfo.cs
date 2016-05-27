﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CExtensions.EFModelGenerator
{
    public class ApplicationInfo
    {
        public static bool TestMode = false;

        public string _generationInfo;

        public string GenerationInfo
        {
            get
            {
                if (_generationInfo == null)
                {
                    StringBuilder sb = new StringBuilder();

                    var assemblyName = Assembly.GetExecutingAssembly().GetName().FullName;
                    if (!TestMode)
                    {
                        sb.AppendLine($"// This code was generated with {assemblyName} on {DateTime.Now}");
                    }
                    sb.AppendLine(@"// please visit : https://github.com/CedricDumont/CExtensions-EFModelGenerator");
                    sb.AppendLine($"// Copyright © Cedric Dumont 2016 (http://www.cedric-dumont.com)");

                    _generationInfo = sb.ToString();
                }

                return _generationInfo;
            }

        }
        public String FormatException(Exception ex, GenerationOptions options)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-----------------------------------------------------------------");
            sb.AppendLine("!!!! An exception occured while generating the code. !!!!");
            sb.AppendLine($"Go to  https://github.com/CedricDumont/CExtensions-EFModelGenerator to check for known issues");
            sb.AppendLine("");
            sb.AppendLine("Or open an issue with the following Information : ");
            sb.AppendLine($"Exception Message : {ex.Message}");
            sb.AppendLine($"Exception Stack : {ex.StackTrace}");

            if (ex.InnerException != null)
            {
                sb.AppendLine("");
                sb.AppendLine($"Inner Exception Message : {ex.Message}");
                sb.AppendLine($"Inner Exception Stack : {ex.StackTrace}");
                sb.AppendLine("-----------------------------------------------------------------");
            }

            sb.AppendLine($"Options: {Environment.NewLine}{JsonConvert.SerializeObject(options)}");

            return sb.ToString();
        }
    }
}