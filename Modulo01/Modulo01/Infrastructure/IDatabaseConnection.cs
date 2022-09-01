using System;
using SQLite;

namespace Modulo01.Infrastructure
{
    public interface IDatabaseConnection
    {
        SQLiteConnection DbConnection();
    }
}

