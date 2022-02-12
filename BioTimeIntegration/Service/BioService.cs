using BioTimeIntegration.Back;
using BioTimeIntegration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioTimeIntegration.Service
{
    public class BioService
    {
        private static readonly string LoginUrl = BioTimeIntegration.Properties.Resources.LoginPath;
        private static readonly string GetAbssense = BioTimeIntegration.Properties.Resources.AbsencePath;
        private static readonly string GetPresent = BioTimeIntegration.Properties.Resources.PresentPath;
        private static readonly RestApi _resApi = new RestApi();

        public static async Task<string> LoginBio()
        {
            LoginModel loginModel = new LoginModel()
            {
                username = BioTimeIntegration.Properties.Resources.User,
                password = BioTimeIntegration.Properties.Resources.Pwd
            };
            var resLogin = await _resApi.PostAsync<ResponseLogin>(LoginUrl, loginModel);

            return resLogin.Token;
        }

        public static async Task<Response<AbsentResponse>> GetAbsentResponse(Parameters param)
        {
            var token = await LoginBio();



            var responAbsense = await _resApi.GetAsync<Response<AbsentResponse>>($"{GetAbssense}?page={param.page}&page_size={param.page_size}5&start_date={param.start_date}&end_date={param.end_date}&departments={param.departments}", token);

            return responAbsense;

        }

        public static async Task<Response<PresentResponse>> GetPresentResponse(Parameters param)
        {
            var token = await LoginBio();



            var responAbsense = await _resApi.GetAsync<Response<PresentResponse>>($"{GetPresent}?page={param.page}&page_size={param.page_size}", token);

            return responAbsense;

        }
    }
}
