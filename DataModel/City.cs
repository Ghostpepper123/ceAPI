﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataModel;

[Keyless]
public partial class City
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("lat")]
    public double Lat { get; set; }

    [Column("lng")]
    public double Lng { get; set; }

    [Column("population")]
    public int Population { get; set; }

    [Column("countryID")]
    public int CountryId { get; set; }

    [ForeignKey("CountryId")]
    public virtual Country Country { get; set; } = null!;
}




