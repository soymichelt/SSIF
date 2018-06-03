using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sadara.Services.SyncService.Service
{

    class Firebase
    {

        private const string APP_SECRET = "ppCcGzgdCTbZQicmLQwg1dH5n1BftVO7EwWek4FS";

        public const string APP_URL = "https://sadaradesktop.firebaseio.com/";

        public string ComposeURL(string path)
        {

            return $"{APP_URL}/{path}";

        }

        private FirebaseClient firebaseClient;

        private void InitializeFirebaseClient()
        {

            this.firebaseClient = new FirebaseClient(
                "",
                new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(APP_SECRET)
                }
            );

        }

        

    }

}