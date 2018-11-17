using System;
using System.Collections;
using Expload.Unity.Codegen;

namespace Expload.Pravda.ExploadCryptoBattleProgram
{
    public class CreateArtefactRequest: ProgramRequest<object>
    {
        public CreateArtefactRequest(byte[] programAddress) : base(programAddress) { }

        protected override object ParseResult(string elem)
        {
            return ExploadTypeConverters.ParseNull(elem);
        }

        public IEnumerator CreateArtefact(byte[] arg0)
        {
            yield return SendRequest("CreateArtefact", new string[] { ExploadTypeConverters.PrintBytes(arg0) });
        }
    }
    public class GetOwnerRequest: ProgramRequest<byte[]>
    {
        public GetOwnerRequest(byte[] programAddress) : base(programAddress) { }

        protected override byte[] ParseResult(string elem)
        {
            return ExploadTypeConverters.ParseBytes(elem);
        }

        public IEnumerator GetOwner(int arg0)
        {
            yield return SendRequest("GetOwner", new string[] { ExploadTypeConverters.PrintInt32(arg0) });
        }
    }
    public class TransferArtefactRequest: ProgramRequest<object>
    {
        public TransferArtefactRequest(byte[] programAddress) : base(programAddress) { }

        protected override object ParseResult(string elem)
        {
            return ExploadTypeConverters.ParseNull(elem);
        }

        public IEnumerator TransferArtefact(byte[] arg0, byte[] arg1, int arg2)
        {
            yield return SendRequest("TransferArtefact", new string[] { ExploadTypeConverters.PrintBytes(arg0), ExploadTypeConverters.PrintBytes(arg1), ExploadTypeConverters.PrintInt32(arg2) });
        }
    }
}