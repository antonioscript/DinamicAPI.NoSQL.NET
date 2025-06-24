# DinamicAPI.NET
API created to simulate request and sending of dynamic objects and storing in the NoSQL Data MongoDB and DynamoDB


# API
![image](https://github.com/user-attachments/assets/0878ae78-7ea8-4e3b-9848-a3ea2d472d49)


# Payload
```json
{
  "accountId": "ACC-001",
  "personType": "PF"
  "holder": {
    "name": "Ana Paula",
    "taxId": "123.456.789-00",
    "documents": {
      "idCard": {
        "number": "55.444.333-2",
        "issuer": "SSP-SP"
      },
      "driverLicense": {
        "number": "99999999999",
        "category": "B",
        "expiration": "2028-12-31"
      }
    }
  },
  "settings": {
    "preferences": {
      "notifications": {
        "email": true,
        "sms": false,
        "push": {
          "android": true,
          "ios": false
        }
      },
      "language": "en-US"
    },
    "security": {
      "twoFactorAuth": true,
      "recentLogins": [
        {
          "date": "2025-06-01T09:15:00Z",
          "ip": "192.168.0.10",
          "location": {
            "country": "Brazil",
            "city": "São Paulo"
          }
        },
        {
          "date": "2025-05-28T21:45:00Z",
          "ip": "192.168.0.15",
          "location": {
            "country": "Brazil",
            "city": "Campinas"
          }
        }
      ]
    }
  },
  "relationships": {
    "dependents": [
      {
        "name": "Lucas",
        "age": 12,
        "schoolHistory": {
          "current": {
            "grade": "7th grade",
            "school": {
              "name": "Central School",
              "address": {
                "street": "Education Street, 45",
                "neighborhood": "Downtown",
                "city": "São Paulo"
              }
            }
          },
          "previous": [
            {
              "grade": "6th grade",
              "school": "Future School"
            }
          ]
        }
      },
      {
        "name": "Marina",
        "age": 14,
        "schoolHistory": {
          "current": {
            "grade": "9th grade",
            "school": {
              "name": "Newton High School",
              "address": {
                "street": "Science Avenue, 900",
                "neighborhood": "Tech District",
                "city": "Campinas"
              }
            }
          },
          "previous": [
            {
              "grade": "8th grade",
              "school": "Galileo School"
            },
            {
              "grade": "7th grade",
              "school": "Galileo School"
            }
          ]
        }
      }
    ]
  }
}


```

----

### Result MongoDB
![image](https://github.com/user-attachments/assets/953b4a29-4726-4f4c-9407-4369ac40aa88)

### Result DynamoDB
![image](https://github.com/user-attachments/assets/cc2a2c43-f7c5-45cb-a974-5952ed5855f4)


## Fixed DTO (Objetct 'Data')
![image](https://github.com/user-attachments/assets/853452e5-b941-48ec-8898-da49f7368c72)

```json
{
  "accountId": "ACC-001",
  "personType": "PF",
  "data": {
    "holder": {
      "name": "Ana Paula",
      "taxId": "123.456.789-00",
      "documents": {
        "idCard": {
          "number": "55.444.333-2",
          "issuer": "SSP-SP"
        },
        "driverLicense": {
          "number": "99999999999",
          "category": "B",
          "expiration": "2028-12-31"
        }
      }
    },
    "settings": {
      "preferences": {
        "notifications": {
          "email": true,
          "sms": false,
          "push": {
            "android": true,
            "ios": false
          }
        },
        "language": "en-US"
      },
      "security": {
        "twoFactorAuth": true,
        "recentLogins": [
          {
            "date": "2025-06-01T09:15:00Z",
            "ip": "192.168.0.10",
            "location": {
              "country": "Brazil",
              "city": "São Paulo"
            }
          },
          {
            "date": "2025-05-28T21:45:00Z",
            "ip": "192.168.0.15",
            "location": {
              "country": "Brazil",
              "city": "Campinas"
            }
          }
        ]
      }
    },
    "relationships": {
      "dependents": [
        {
          "name": "Lucas",
          "age": 12,
          "schoolHistory": {
            "current": {
              "grade": "7th grade",
              "school": {
                "name": "Central School",
                "address": {
                  "street": "Education Street, 45",
                  "neighborhood": "Downtown",
                  "city": "São Paulo"
                }
              }
            },
            "previous": [
              {
                "grade": "6th grade",
                "school": "Future School"
              }
            ]
          }
        },
        {
          "name": "Marina",
          "age": 14,
          "schoolHistory": {
            "current": {
              "grade": "9th grade",
              "school": {
                "name": "Newton High School",
                "address": {
                  "street": "Science Avenue, 900",
                  "neighborhood": "Tech District",
                  "city": "Campinas"
                }
              }
            },
            "previous": [
              {
                "grade": "8th grade",
                "school": "Galileo School"
              },
              {
                "grade": "7th grade",
                "school": "Galileo School"
              }
            ]
          }
        }
      ]
    }
  }
}

```

## Fixed DTO (without 'Data')
``` json
{
  "accountId": "ACC-001",
  "personType": "PF",
  "holder": {
    "name": "Ana Paula",
    "taxId": "123.456.789-00",
    "documents": {
      "idCard": {
        "number": "55.444.333-2",
        "issuer": "SSP-SP"
      },
      "driverLicense": {
        "number": "99999999999",
        "category": "B",
        "expiration": "2028-12-31"
      }
    }
  },
  "settings": {
    "preferences": {
      "notifications": {
        "email": true,
        "sms": false,
        "push": {
          "android": true,
          "ios": false
        }
      },
      "language": "en-US"
    },
    "security": {
      "twoFactorAuth": true,
      "recentLogins": [
        {
          "date": "2025-06-01T09:15:00Z",
          "ip": "192.168.0.10",
          "location": {
            "country": "Brazil",
            "city": "São Paulo"
          }
        },
        {
          "date": "2025-05-28T21:45:00Z",
          "ip": "192.168.0.15",
          "location": {
            "country": "Brazil",
            "city": "Campinas"
          }
        }
      ]
    }
  },
  "relationships": {
    "dependents": [
      {
        "name": "Lucas",
        "age": 12,
        "schoolHistory": {
          "current": {
            "grade": "7th grade",
            "school": {
              "name": "Central School",
              "address": {
                "street": "Education Street, 45",
                "neighborhood": "Downtown",
                "city": "São Paulo"
              }
            }
          },
          "previous": [
            {
              "grade": "6th grade",
              "school": "Future School"
            }
          ]
        }
      },
      {
        "name": "Marina",
        "age": 14,
        "schoolHistory": {
          "current": {
            "grade": "9th grade",
            "school": {
              "name": "Newton High School",
              "address": {
                "street": "Science Avenue, 900",
                "neighborhood": "Tech District",
                "city": "Campinas"
              }
            }
          },
          "previous": [
            {
              "grade": "8th grade",
              "school": "Galileo School"
            },
            {
              "grade": "7th grade",
              "school": "Galileo School"
            }
          ]
        }
      }
    ]
  }
}

```

### MongoDB
![image](https://github.com/user-attachments/assets/348fa61e-1947-46bc-b987-1718aa5baa5d)



# References
https://stackoverflow.com/questions/44935976/how-to-post-a-dynamic-json-property-to-a-c-sharp-asp-net-core-web-api-using-mong

https://www.mongodb.com/community/forums/t/mongo-model-for-dynamic-fields/206150

https://www.mongodb.com/developer/languages/csharp/polymorphism-with-mongodb-csharp/

https://www.jsongenerator.io/


## Case

![image](https://github.com/user-attachments/assets/8c5032d4-37a2-4542-93e6-b95c49c71c11)

----

![image](https://github.com/user-attachments/assets/c71c41f5-1da2-49e1-9bc7-4a7899d11e17)


------

![image](https://github.com/user-attachments/assets/61519bcd-4774-4fb4-ba81-87aa9d752f81)




