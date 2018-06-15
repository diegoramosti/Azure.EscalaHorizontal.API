# Azure.EscalaHorizontal.API

Objetivo dessa POC é evidenciar o comportamento do auto scalling do azure. 
•	Criamos uma API para retornar apenas o nome da máquina que está sendo executada e IP.
•	Para consumir a API, criamos um batch onde criamos o client apenas uma vez e executamos diversas requisições em paralelo. 
•	Em um processo separado no batch vamos totalizando o total de requisições por servidor, baseado no retorno da API.
Projeto:  https://github.com/diegoramosti/Azure.EscalaHorizontal.API
Testes:
1-	Deixamos a configuração com auto scalling, quando o processador atingisse 20% deveria incrementar uma instância, chegando no máximo em três.
a.	API iniciou retornando apenas um nome de máquina.
b.	Após 5 minutos, começou a responder com dois nomes de máquinas.
c.	Em seguida, 3 nomes de máquinas.

2-	Deixamos a configuração com número específico de instâncias e com a quantidade de apenas duas.
a.	API já de início retornou dois nomes de máquinas diferentes.






