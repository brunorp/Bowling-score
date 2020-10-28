# Bowling-score

* Uma função que realiza cada jogada e uma função que calcula os pontos totais de cada jogador.
* Na função que realiza as jogadas, é adicionado a uma lista o numero de pinos derrubados naquela jogada.
* Na função que cacula os pontos totais, é feita a verificação de qual tipo de pontuação foi feita (strike, spare, pontuação normal), 
a partir dessa verificação, é calculado o total de pontos de acordo com o tipo de pontuação.
* A verificação do tipo de pontuação pode ser feita em uma outra função...

## Regras

1. Strike: Quando todos os pinos são derrubados em uma única jogada. 
&nbsp;&nbsp;&nbsp;&nbsp; * Quando é feito um strike, a pontuação é a soma de 10 com as duas jogadas do próximo frame.

2. Spare: Quando todos os pinos são derrubados em 2 jogadas consecutivas. 
&nbsp;&nbsp;&nbsp;&nbsp;* Quando é feito um spare, a pontuação é a soma de 10 com a primeira jogada do próximo frame.

3. Quando é feito 2 ou mais strikes em sequência, a pontuação é a soma de 10 + 10 + a primeira jogada do frame em sequência.
