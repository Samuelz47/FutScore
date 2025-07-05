using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FutScore.Modelos;

public enum Posicao                             /// enum Posicao, para evitar o uso de posição que não esteja enquadrada
{
    Goleiro,
    Zagueiro,
    Lateral,
    Volante,
    MeioCampo,
    Ponta,
    Centroavante
}
