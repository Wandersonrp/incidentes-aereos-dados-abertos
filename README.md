<h1 align="center"> Api de Listagem e Filtragem de Ocorrências Aéreas </h1>

<div align="center">

![GitHub top language](https://img.shields.io/github/languages/top/Wandersonrp/incidentes-aereos-dados-abertos?style=plastic) ![GitHub last commit](https://img.shields.io/github/last-commit/Wandersonrp/incidentes-aereos-dados-abertos?style=plastic)
</div>


<hr>
<br>

Esta é uma API pública para consulta e filtragem de ocorrências aéreas. A API fornece informações sobre incidentes e acidentes envolvendo aeronaves, com base em dados fornecidos pela Agência Nacional de Aviação Civil - ANAC.

<hr>
<br>

## Endpoints

A API disponibiliza os seguintes endpoints para consulta:
```
/ocorrencias/v1 - retorna uma lista de todas as ocorrências
```
```
/ocorrencias/v1/{numeroOcorrencia} - retorna detalhes de uma ocorrência específica, com base em seu número de ocorrência
```
```
/ocorrencias/v1/ano/{ano} - retorna uma lista de ocorrências pelo ano informado
```
```
/ocorrencias/v1/uf/{uf} - retorna uma lista de ocorrências pela Unidade Federativa - UF informada
```
```
/ocorrencias/v1/fatais - retorna uma lista de ocorrências que houve vítimas fatais
```
```
/ocorrencias/v1/icao/{icao} - retorna uma lista de ocorrências pelo códido ICAO - International Civil Aviation Organization
```
```
/ocorrencias/v1/municipio/{municipio} - retorna uma lista de ocorrências pelo município informado
```
```
/ocorrencias/v1/fabricante/{fabricante} - retorna uma lista de ocorrências pelo nome de fabricante de aeronaves informado
```
```
/ocorrencias/v1/operacao/{operacao} - retorna uma lista de ocorrências por tipo de operação
```
```
/ocorrencias/v1/periodo - retorna uma lista de ocorrências pelo período informado. Parâmetros 'anoInicio' e 'anoFinal'
```
```
/ocorrencias/v1/fase/{faseOperacao} - retorna uma lista de ocorrências pela fase de operação informada
```

<br>
<hr>

### Descrição
<br>

```
GET - /ocorrencias/v1 - Retorna a lista de todas as ocorrências.
```

<hr>

```
GET - /ocorrencias/v1/ano/{ano} - Retorna a lista de todas as ocorrências pelo ano infromado.

Ex.: /ocorrencias/v1/ano/2020
[
    {
        "id": 76,
        "numero_da_Ocorrencia": "34788",
        "numero_da_Ficha": "202068291",
        "operador_Padronizado": "CARLOS ALEXANDRE QUADRADO",
        "classificacao_da_Ocorrencia": null,
        "data_da_Ocorrencia": "2020-05-17T00:00:00",
        "hora_da_Ocorrencia": null,
        "municipio": "MACATUBA",
        "uf": "SP",
        "regiao": "Sudeste",
        "descricao_do_Tipo": null,
        "icao": "Fora de Aeródromo",
        "latitude": null,
        "longitude": null,
        "tipo_de_Aerodromo": "-",
        "historico": null,
        "matricula": "PUACR",
        "categoria_da_Aeronave": "PET",
        "operador": "CARLOS ALEXANDRE QUADRADO",
        "tipo_de_Ocorrencia": null,
        "fase_da_Operacao": null,
        "operacao": null,
        "danos_a_Aeronave": null,
        "aerodromo_de_Destino": null,
        "aerodromo_de_Origem": null,
        "lesoes_Fatais_Tripulantes": 0,
        "lesoes_Fatais_Passageiros": 0,
        "lesoes_Fatais_Terceiros": 0,
        "lesoes_Graves_Tripulantes": 0,
        "lesoes_Graves_Passageiros": 0,
        "lesoes_Graves_Terceiros": 0,
        "lesoes_Leves_Tripulantes": 0,
        "lesoes_Leves_Passageiros": 0,
        "lesoes_Leves_Terceiros": 0,
        "ilesos_Tripulantes": 0,
        "ilesos_Passageiros": 0,
        "lesoes_Desconhecidas_Tripulantes": 0,
        "lesoes_Desconhecidas_Passageiros": 0,
        "lesoes_Desconhecidas_Terceiros": 0,
        "modelo": "FEN-U-201",
        "cls": "L1P",
        "tipo_ICAO": "ULAC",
        "pmd": 450,
        "numero_de_Assentos": 2,
        "nome_do_Fabricante": "FENIX",
        "psso": "falso"
    },
    {
        "id": 55,
        "numero_da_Ocorrencia": "34606",
        "numero_da_Ficha": "202058653",
        "operador_Padronizado": "WW SERVICOS AERO AGRICOLAS LTDA - ME",
        "classificacao_da_Ocorrencia": null,
        "data_da_Ocorrencia": "2020-04-03T00:00:00",
        "hora_da_Ocorrencia": null,
        "municipio": "FRUTAL",
        "uf": "MG",
        "regiao": "Sudeste",
        "descricao_do_Tipo": null,
        "icao": "APUA",
        "latitude": null,
        "longitude": null,
        "tipo_de_Aerodromo": "APUA",
        "historico": null,
        "matricula": "PTOMW",
        "categoria_da_Aeronave": "S05",
        "operador": "WW SERVICOS AERO AGRICOLAS LTDA - ME",
        "tipo_de_Ocorrencia": null,
        "fase_da_Operacao": null,
        "operacao": null,
        "danos_a_Aeronave": null,
        "aerodromo_de_Destino": null,
        "aerodromo_de_Origem": null,
        "lesoes_Fatais_Tripulantes": 0,
        "lesoes_Fatais_Passageiros": 0,
        "lesoes_Fatais_Terceiros": 0,
        "lesoes_Graves_Tripulantes": 0,
        "lesoes_Graves_Passageiros": 0,
        "lesoes_Graves_Terceiros": 0,
        "lesoes_Leves_Tripulantes": 0,
        "lesoes_Leves_Passageiros": 0,
        "lesoes_Leves_Terceiros": 0,
        "ilesos_Tripulantes": 0,
        "ilesos_Passageiros": 0,
        "lesoes_Desconhecidas_Tripulantes": 0,
        "lesoes_Desconhecidas_Passageiros": 0,
        "lesoes_Desconhecidas_Terceiros": 0,
        "modelo": "PA-25-235",
        "cls": "L1P",
        "tipo_ICAO": "PA25",
        "pmd": 1315,
        "numero_de_Assentos": 1,
        "nome_do_Fabricante": "PIPER AIRCRAFT",
        "psso": "verdadeiro"
    }
]    
```
