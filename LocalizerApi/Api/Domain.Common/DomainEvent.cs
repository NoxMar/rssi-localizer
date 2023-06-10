using System.Reflection;
using MediatR;

namespace Domain.Common;

public record DomainEvent : INotification;