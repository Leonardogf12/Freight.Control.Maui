﻿using freight.control.maui.MVVM.Models;
using SQLite;

namespace freight.control.maui.Repositories;

public class FreightRepository : GenericRepository<FreightModel>
{
    private readonly SQLiteAsyncConnection _db;

    public FreightRepository()
    {
        _db = new SQLiteAsyncConnection(App.dbPath);
    }
}