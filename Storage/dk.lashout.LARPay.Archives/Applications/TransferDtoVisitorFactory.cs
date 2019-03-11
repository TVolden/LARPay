using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Archives.Applications
{
    public class TransferDtoVisitorFactory
    {
        private readonly Messages _messages;

        public TransferDtoVisitorFactory(Messages messages)
        {
            _messages = messages;
        }

        public TransferDtoVisitor CreateVisitor(Guid accountCustomerId)
        {
            return new TransferDtoVisitor(_messages, accountCustomerId);
        }
    }
}
