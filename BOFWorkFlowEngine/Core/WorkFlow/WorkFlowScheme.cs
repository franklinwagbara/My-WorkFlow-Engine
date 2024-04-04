using BOFWorkFlowEngine.Core.Interfaces;
using BOFWorkFlowEngine.Exceptions;
using BOFWorkFlowEngine.Model;
using Newtonsoft.Json;

namespace BOFWorkFlowEngine.Core.WorkFlow
{
    public class WorkFlowScheme : IWorkFlowScheme
    {
        public Scheme Scheme { get; private set; }

        public WorkFlowScheme(string schemeCode) 
        {
            Scheme = Parse(GetSchemeFromDb(schemeCode));
        }

        public WorkFlowScheme(Scheme scheme)
        {
            Scheme = scheme;
        }

        public string Serialize(Scheme scheme)
        {
            throw new NotImplementedException();
        }

        public Scheme? Parse(string scheme)
        {
            var res = JsonConvert.DeserializeObject<Scheme>(scheme);
            return res;
        }

        public Scheme GetScheme()
        {
            return Scheme;
        }

        public Scheme GetSchemeByValue(string scheme)
        {
            return Parse(scheme);
        }

        public Scheme GetSchemeByCode(string schemeCode)
        {
            var scheme = GetSchemeFromDb(schemeCode);
            return Parse(scheme);
        }

        public string ISerializeScheme(Scheme scheme)
        {
            return Serialize(scheme);
        }

        public string GetSchemeFromDb(string schemeCode)
        {
            var json = @"{
  ""code"": ""testCode"",
  ""name"": ""Test Process"",
  ""actors"": [
    {
      ""name"": ""TestCompany"",
      ""value"": ""Test Company""
    },
    {
      ""name"": ""TestCompany"",
      ""value"": ""Test Company""
    }
  ],
  ""parameters"": [
    {
      ""name"": ""Comment"",
      ""type"": ""string"",
      ""purpose"": ""temporary""
    }
  ],
  ""commands"": [
    {
      ""name"": ""submitApplication"",
      ""inputParameters"": [
        {
          ""parameterRef"": {
            ""name"": ""Comment"",
            ""isRequired"": ""false"",
            ""defaultValue"": """",
            ""nameRef"": ""Comment""
          }
        }
      ]
    },
    {
      ""name"": ""ApproveApplication"",
      ""inputParameters"": [
        {
          ""parameterRef"": {
            ""name"": ""Comment"",
            ""isRequired"": ""false"",
            ""defaultValue"": """",
            ""nameRef"": ""Comment""
          }
        }
      ]
    },
    {
      ""name"": ""RejectApplication"",
      ""inputParameters"": [
        {
          ""parameterRef"": {
            ""name"": ""Comment"",
            ""isRequired"": ""false"",
            ""defaultValue"": """",
            ""nameRef"": ""Comment""
          }
        }
      ]
    }
  ],
  ""comments"": [
    {
      ""name"": ""Comment"",
      ""value"": ""This is comment 1""
    },
    {
      ""name"": ""Comment"",
      ""value"": ""This is comment 2""
    },
    {
      ""name"": ""Comment"",
      ""value"": ""This is comment 3""
    },
    {
      ""name"": ""Comment"",
      ""value"": ""This is comment 4""
    }
  ],
  ""activities"": [
    {
      ""name"": ""ApplicationSubmittedToReviewer"",
      ""state"": ""ApplicationSubmitted"",
      ""isInitial"": ""True"",
      ""isFinal"": ""False"",
      ""isForSetState"": ""True"",
      ""IsAutoSchemeUpdate"": ""True""
    },
    {
      ""name"": ""ReviewerApproving"",
      ""state"": ""ReviewerApproving"",
      ""isInitial"": ""false"",
      ""isFinal"": ""false"",
      ""isForSetState"": ""true"",
      ""IsAutoSchemeUpdate"": ""true""
    },
    {
      ""name"": ""SupervisorApproving"",
      ""state"": ""SupervisorApproving"",
      ""isInitial"": ""false"",
      ""isFinal"": ""false"",
      ""isForSetState"": ""true"",
      ""IsAutoSchemeUpdate"": ""true""
    },
    {
      ""name"": ""ManagerApproving"",
      ""state"": ""ManagerApproving"",
      ""isInitial"": ""false"",
      ""isFinal"": ""false"",
      ""isForSetState"": ""true"",
      ""IsAutoSchemeUpdate"": ""true""
    },
    {
      ""name"": ""ECApproving"",
      ""state"": ""ECApproving"",
      ""isInitial"": ""false"",
      ""isFinal"": ""false"",
      ""isForSetState"": ""true"",
      ""IsAutoSchemeUpdate"": ""true""
    }
  ],
  ""transitions"": [
    {
      ""name"": ""CompanySubmitting_Direct"",
      ""From"": ""ApplicationSubmittedToReviewer"",
      ""To"": ""ReviewerApproving"",
      ""restrictions"": [
        {
          ""type"": ""allow"",
          ""nameRef"": ""reviewer""
        }
      ],
      ""triggers"": [
        {
          ""type"": ""command"",
          ""nameRef"": ""SubmitApplication""
        }
      ],
      ""conditions"": [
        {
          ""type"": ""always""
        }
      ]
    },
    {
      ""name"": ""ReviewerReject_Direct"",
      ""From"": ""ReviewerApproving"",
      ""To"": ""ApplicationSubmittedToReviewer"",
      ""restrictions"": [
        {
          ""type"": ""allow"",
          ""nameRef"": ""reviewer""
        }
      ],
      ""triggers"": [
        {
          ""type"": ""command"",
          ""nameRef"": ""RejectApplication""
        }
      ],
      ""conditions"": [
        {
          ""type"": ""always""
        }
      ]
    },
    {
      ""name"": ""ReviewerApproving_Direct"",
      ""From"": ""ReviewerApproving"",
      ""To"": ""SupervisorApproving"",
      ""restrictions"": [
        {
          ""type"": ""allow"",
          ""nameRef"": ""reviewer""
        }
      ],
      ""triggers"": [
        {
          ""type"": ""command"",
          ""nameRef"": ""ApproveApplication""
        }
      ],
      ""conditions"": [
        {
          ""type"": ""always""
        }
      ]
    },
    {
      ""name"": ""SupervisorRejecting_Direct"",
      ""From"": ""SupervisorApproving"",
      ""To"": ""ReviewerApproving"",
      ""restrictions"": [
        {
          ""type"": ""allow"",
          ""nameRef"": ""reviewer""
        }
      ],
      ""triggers"": [
        {
          ""type"": ""command"",
          ""nameRef"": ""RejectApplication""
        }
      ],
      ""conditions"": [
        {
          ""type"": ""always""
        }
      ]
    },
    {
      ""name"": ""SupervisorApproving_Direct"",
      ""From"": ""SupervisorApproving"",
      ""To"": ""ECApproving"",
      ""restrictions"": [
        {
          ""type"": ""allow"",
          ""nameRef"": ""reviewer""
        }
      ],
      ""triggers"": [
        {
          ""type"": ""command"",
          ""nameRef"": ""ApproveApplication""
        }
      ],
      ""conditions"": [
        {
          ""type"": ""always""
        }
      ]
    },
    {
      ""name"": ""ECRejecting_Direct"",
      ""From"": ""ECApproving"",
      ""To"": ""SupervisorApproving"",
      ""restrictions"": [
        {
          ""type"": ""allow"",
          ""nameRef"": ""reviewer""
        }
      ],
      ""triggers"": [
        {
          ""type"": ""command"",
          ""nameRef"": ""RejectApplication""
        }
      ],
      ""conditions"": [
        {
          ""type"": ""always""
        }
      ]
    }
  ]
}
";

            return json;
        }

        public void SetSchemeByCode(string schemeCode)
        {
            var schemeString = GetSchemeFromDb(schemeCode) ?? throw new NotFoundException($"Scheme with code={schemeCode} was not found.");

            SetSchemeByValue(schemeString);
        }

        public void SetSchemeByValue(string scheme)
        {
            Scheme = Parse(scheme);
        }
    }
}
