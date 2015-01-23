using System;

namespace XamarinFormsOAuth2Demo
{
	public class GoogleUserInfo
	{
		public GoogleUserInfo ()
		{
		}

		[Newtonsoft.Json.JsonProperty ("id")]
		public string id{ get; set; }

		[Newtonsoft.Json.JsonProperty ("email")]
		public string email{ get; set; }

		[Newtonsoft.Json.JsonProperty ("verified_email")]
		public bool verified_email{ get; set; }

		[Newtonsoft.Json.JsonProperty ("name")]
		public string name{ get; set; }

		[Newtonsoft.Json.JsonProperty ("given_name")]
		public string given_name{ get; set; }

		[Newtonsoft.Json.JsonProperty ("family_name")]
		public string family_name{ get; set; }

		[Newtonsoft.Json.JsonProperty ("picture")]
		public string picture{ get; set; }

	}
}

