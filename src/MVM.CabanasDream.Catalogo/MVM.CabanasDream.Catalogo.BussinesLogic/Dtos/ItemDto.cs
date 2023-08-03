using System;
using System.ComponentModel.DataAnnotations;
using MVM.CabanasDream.BussinesLogic.Enum;
using Newtonsoft.Json;

namespace MVM.CabanasDream.BussinesLogic.Dtos.Requests;

public class ItemDto
{
    [Required(ErrorMessage = "O campo {0} é obrigatorio")]
    [EnumDataType(typeof(EObjetoDeFesta), ErrorMessage = "O campo {0} deve ter um valor válido")]
    public EObjetoDeFesta ObjetoFesta { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatorio")]
    [Range(0, 1000, ErrorMessage = "O campo {0} contém um valor inválido")]
    public int Quantidade { get; set; }
}

