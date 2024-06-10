﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum TransactionType
{
    Incomes,
    Spendings
}

public class Transaction
{
    [Key]
    public int TransactionID { get; set; }
    public int UserID { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }


    public TransactionType Type { get; set; }
    public User User { get; set; }
}