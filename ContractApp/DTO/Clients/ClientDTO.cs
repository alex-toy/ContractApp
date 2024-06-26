﻿namespace RecrutementNet.DTO.Clients;

public class ClientDTO
{
    public ClientDTO(int id, string name, string address)
    {
        Id = id;
        Name = name;
        Address = address;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}
