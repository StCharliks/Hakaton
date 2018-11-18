using System;
using System.Collections;
using Expload.Unity.Codegen;

namespace Expload.Pravda.ExploadCryptoBattleProgram
{
    public class CreateArtifactRequest: ProgramRequest<int>
    {
        public CreateArtifactRequest(byte[] programAddress) : base(programAddress) { }

        protected override int ParseResult(string elem)
        {
            return ExploadTypeConverters.ParseInt32(elem);
        }

        public IEnumerator Test(byte[] arg0)
        {
            yield return SendRequest("CreateArtifact", new string[] { ExploadTypeConverters.PrintBytes(arg0) }, true);
        }

        public IEnumerator Call(byte[] arg0)
        {
            yield return SendRequest("CreateArtifact", new string[] { ExploadTypeConverters.PrintBytes(arg0) }, false);
        }

        // Same as Call
        // Deprecated
        public IEnumerator CreateArtifact(byte[] arg0)
        {
            yield return SendRequest("CreateArtifact", new string[] { ExploadTypeConverters.PrintBytes(arg0) }, false);
        }
    }
    public class GetBalanceOfRequest: ProgramRequest<int>
    {
        public GetBalanceOfRequest(byte[] programAddress) : base(programAddress) { }

        protected override int ParseResult(string elem)
        {
            return ExploadTypeConverters.ParseInt32(elem);
        }

        public IEnumerator Test(byte[] arg0)
        {
            yield return SendRequest("GetBalanceOf", new string[] { ExploadTypeConverters.PrintBytes(arg0) }, true);
        }

        public IEnumerator Call(byte[] arg0)
        {
            yield return SendRequest("GetBalanceOf", new string[] { ExploadTypeConverters.PrintBytes(arg0) }, false);
        }

        // Same as Call
        // Deprecated
        public IEnumerator GetBalanceOf(byte[] arg0)
        {
            yield return SendRequest("GetBalanceOf", new string[] { ExploadTypeConverters.PrintBytes(arg0) }, false);
        }
    }
    public class GetOwnerRequest: ProgramRequest<byte[]>
    {
        public GetOwnerRequest(byte[] programAddress) : base(programAddress) { }

        protected override byte[] ParseResult(string elem)
        {
            return ExploadTypeConverters.ParseBytes(elem);
        }

        public IEnumerator Test(int arg0)
        {
            yield return SendRequest("GetOwner", new string[] { ExploadTypeConverters.PrintInt32(arg0) }, true);
        }

        public IEnumerator Call(int arg0)
        {
            yield return SendRequest("GetOwner", new string[] { ExploadTypeConverters.PrintInt32(arg0) }, false);
        }

        // Same as Call
        // Deprecated
        public IEnumerator GetOwner(int arg0)
        {
            yield return SendRequest("GetOwner", new string[] { ExploadTypeConverters.PrintInt32(arg0) }, false);
        }
    }
    public class TransferArtifactRequest: ProgramRequest<object>
    {
        public TransferArtifactRequest(byte[] programAddress) : base(programAddress) { }

        protected override object ParseResult(string elem)
        {
            return ExploadTypeConverters.ParseNull(elem);
        }

        public IEnumerator Test(byte[] arg0, byte[] arg1, int arg2)
        {
            yield return SendRequest("TransferArtifact", new string[] { ExploadTypeConverters.PrintBytes(arg0), ExploadTypeConverters.PrintBytes(arg1), ExploadTypeConverters.PrintInt32(arg2) }, true);
        }

        public IEnumerator Call(byte[] arg0, byte[] arg1, int arg2)
        {
            yield return SendRequest("TransferArtifact", new string[] { ExploadTypeConverters.PrintBytes(arg0), ExploadTypeConverters.PrintBytes(arg1), ExploadTypeConverters.PrintInt32(arg2) }, false);
        }

        // Same as Call
        // Deprecated
        public IEnumerator TransferArtifact(byte[] arg0, byte[] arg1, int arg2)
        {
            yield return SendRequest("TransferArtifact", new string[] { ExploadTypeConverters.PrintBytes(arg0), ExploadTypeConverters.PrintBytes(arg1), ExploadTypeConverters.PrintInt32(arg2) }, false);
        }
    }
}