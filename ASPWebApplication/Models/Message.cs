﻿using Microsoft.AspNetCore.Identity;

namespace ASPWebApplication.Models;

public class Message
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public DateTime Timestamp { get; set; }

    // Foreign key to the ChatRoom
    public required int ChatRoomId { get; set; }
    public required ChatRoom ChatRoomObj { get; set; }

    public required string SenderId { get; set; }
    public required IdentityUser SenderObj{ get; set; }
}
