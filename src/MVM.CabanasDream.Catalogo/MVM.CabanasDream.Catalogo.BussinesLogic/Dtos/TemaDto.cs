using System;
using System.ComponentModel.DataAnnotations;
using MVM.CabanasDream.BussinesLogic.Enum;
using Newtonsoft.Json;

namespace MVM.CabanasDream.BussinesLogic.Dtos.Requests;

public class TemaDto
{
    [Required(ErrorMessage = "O campo {0} é obrigatorio")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "O campo {0} é obrigatorio")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatorio")]
    public string Imagem { get; set; }
}

