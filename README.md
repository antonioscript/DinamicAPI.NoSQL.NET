# DinamicAPI.NET
API created to simulate request and sending of dynamic objects and storing in the NoSQL Bank MongoDB


# Payload
```json
{
  "accountId": "ACC-001",
  "titular": {
    "nome": "Ana Paula",
    "cpf": "123.456.789-00"
  },
  "enderecos": [
    {
      "tipo": "Residencial",
      "logradouro": "Rua das Flores, 123",
      "cidade": "São Paulo",
      "estado": "SP"
    },
    {
      "tipo": "Comercial",
      "logradouro": "Av. Paulista, 1000",
      "cidade": "São Paulo",
      "estado": "SP"
    }
  ],
  "contatos": [
    {
      "tipo": "Telefone",
      "valor": "(11) 99999-9999"
    },
    {
      "tipo": "Email",
      "valor": "ana.paula@email.com"
    }
  ],
  "transacoes": [
    {
      "data": "2025-06-05T10:00:00Z",
      "descricao": "Depósito",
      "valor": 1000.00
    },
    {
      "data": "2025-06-06T14:30:00Z",
      "descricao": "Pagamento Boleto",
      "valor": -350.00
    }
  ],
  "dependentes": [
    {
      "nome": "Lucas",
      "idade": 12,
      "beneficios": [
        {
          "tipo": "Bolsa Estudo",
          "valorMensal": 500.00
        }
      ],
      "cursos": [
        {
          "nome": "Inglês",
          "nivel": "Intermediário"
        },
        {
          "nome": "Robótica",
          "nivel": "Iniciante"
        }
      ]
    },
    {
      "nome": "Marina",
      "idade": 15,
      "beneficios": [
        {
          "tipo": "Plano de Saúde",
          "valorMensal": 300.00
        }
      ],
      "cursos": [
        {
          "nome": "Programação",
          "nivel": "Avançado"
        }
      ]
    },
    {
      "nome": "Rafael",
      "idade": 9,
      "beneficios": [],
      "cursos": []
    }
  ]
}
```

# References

https://www.mongodb.com/community/forums/t/mongo-model-for-dynamic-fields/206150


https://www.mongodb.com/developer/languages/csharp/polymorphism-with-mongodb-csharp/
