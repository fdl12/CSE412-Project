﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace InventoryManagmentSystem.Models;

public partial class Inventory
{
    public int? WarehouseId { get; set; }

    public int? ProductId { get; set; }

    public int? SupplierId { get; set; }

    public int? ReorderQuantity { get; set; }

    public int? StockOnHand { get; set; }

    public int? SafetyStock { get; set; }

    public int? ReorderLevel { get; set; }

    public virtual Product Product { get; set; }

    public virtual Supplier Supplier { get; set; }

    public virtual Warehouse Warehouse { get; set; }
}