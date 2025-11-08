using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServer.Data;

public class Message
{
    [Key]
    public int MessageId { get; set; }

    [ForeignKey(DbTableNames.ApplicationUser)]
    public required string SentUserId { get; set; }

    public required ApplicationUser SentUser { get; set; }

    [ForeignKey(DbTableNames.Chat)]
    public required int ChatID { get; set; }

    public required Chat Chat { get; set; }

    public required string MessageContent { get; set; }

    public required string SentDate { get; set; }

    public required string SentTime { get; set; }
}
