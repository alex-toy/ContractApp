﻿using Apollo.Models;

namespace RecrutementNet.DTO;

public class ContractUpsertDTO
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }
    public int ClientId { get; set; }
    public int UserId { get; set; }

    public Contract ToModel()
    {
        return new Contract(Id, Date, ClientId, UserId);
    }
}
