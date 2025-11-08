using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServer.Data;

public class Message
{
    [Key]
    public int MessageId { get; set; }

    [ForeignKey("ApplicationUser")]
    public required string SentUserId { get; set; }

    [ForeignKey("ApplicationUser")]
    public required string ReceivedUserId { get; set; }

    public required ApplicationUser SentUser { get; set; }

    public required ApplicationUser ReceivedUser { get; set; }

    public required string MessageContent { get; set; }

    public required string SentDate { get; set; }

    public required string SentTime { get; set; }
}
