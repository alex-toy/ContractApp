
using Apollo.Models;

namespace Apollo.Data;
static class ContractsDbSet
{
    public static List<Contract> Data = new() {
        new(1, new DateOnly(2001, 10, 10), 1, 3),
        new(2, new DateOnly(2001, 10, 12), 1, 2),
        new(3, new DateOnly(2001, 11, 16), 1, 1),
        new(4, new DateOnly(2001, 11, 19), 2, 1),
        new(5, new DateOnly(2001, 12, 1), 2, 1),
    };
}