using System;
using System.Collections;
using Expload.Unity.Codegen;

namespace Expload.Pravda.ExploadCryptoBattleProgram
{
    public class CreateArtefactRequest: ProgramRequest<int>
    {
        public CreateArtefactRequest(byte[] programAddress) : base(programAddress) { }

        protected override int ParseResult(string elem)
        {
            return ExploadTypeConverters.ParseInt32(elem);
        }

        public IEnumerator Test(byte[] arg0)
        {
            yield return SendRequest("CreateArtefact", new string[] { ExploadTypeConverters.PrintBytes(arg0) }, true);
        }

        public IEnumerator Call(byte[] arg0)
        {
            yield return SendRequest("CreateArtefact", new string[] { ExploadTypeConverters.PrintBytes(arg0) }, false);
        }

        // Same as Call
        // Deprecated
        public IEnumerator CreateArtefact(byte[] arg0)
        {
            yield return SendRequest("CreateArtefact", new string[] { ExploadTypeConverters.PrintBytes(arg0) }, false);
        }
    }
    public class GetArtefactAtPosRequest: ProgramRequest<int>
    {
        public GetArtefactAtPosRequest(byte[] programAddress) : base(programAddress) { }

        protected override int ParseResult(string elem)
        {
            return ExploadTypeConverters.ParseInt32(elem);
        }

        public IEnumerator Test(byte[] arg0, int arg1)
        {
            yield return SendRequest("GetArtefactAtPos", new string[] { ExploadTypeConverters.PrintBytes(arg0), ExploadTypeConverters.PrintInt32(arg1) }, true);
        }

        public IEnumerator Call(byte[] arg0, int arg1)
        {
            yield return SendRequest("GetArtefactAtPos", new string[] { ExploadTypeConverters.PrintBytes(arg0), ExploadTypeConverters.PrintInt32(arg1) }, false);
        }

        // Same as Call
        // Deprecated
        public IEnumerator GetArtefactAtPos(byte[] arg0, int arg1)
        {
            yield return SendRequest("GetArtefactAtPos", new string[] { ExploadTypeConverters.PrintBytes(arg0), ExploadTypeConverters.PrintInt32(arg1) }, false);
        }
    }
    public class GetArtefactsRequest: ProgramRequest<string>
    {
        public GetArtefactsRequest(byte[] programAddress) : base(programAddress) { }

        protected override string ParseResult(string elem)
        {
            return ExploadTypeConverters.ParseUtf8(elem);
        }

        public IEnumerator Test(byte[] arg0)
        {
            yield return SendRequest("GetArtefacts", new string[] { ExploadTypeConverters.PrintBytes(arg0) }, true);
        }

        public IEnumerator Call(byte[] arg0)
        {
            yield return SendRequest("GetArtefacts", new string[] { ExploadTypeConverters.PrintBytes(arg0) }, false);
        }

        // Same as Call
        // Deprecated
        public IEnumerator GetArtefacts(byte[] arg0)
        {
            yield return SendRequest("GetArtefacts", new string[] { ExploadTypeConverters.PrintBytes(arg0) }, false);
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
    public class GetServerAddressRequest: ProgramRequest<byte[]>
    {
        public GetServerAddressRequest(byte[] programAddress) : base(programAddress) { }

        protected override byte[] ParseResult(string elem)
        {
            return ExploadTypeConverters.ParseBytes(elem);
        }

        public IEnumerator Test()
        {
            yield return SendRequest("GetServerAddress", new string[] {  }, true);
        }

        public IEnumerator Call()
        {
            yield return SendRequest("GetServerAddress", new string[] {  }, false);
        }

        // Same as Call
        // Deprecated
        public IEnumerator GetServerAddress()
        {
            yield return SendRequest("GetServerAddress", new string[] {  }, false);
        }
    }
    public class TransferArtefactRequest: ProgramRequest<object>
    {
        public TransferArtefactRequest(byte[] programAddress) : base(programAddress) { }

        protected override object ParseResult(string elem)
        {
            return ExploadTypeConverters.ParseNull(elem);
        }

        public IEnumerator Test(int arg0, byte[] arg1)
        {
            yield return SendRequest("TransferArtefact", new string[] { ExploadTypeConverters.PrintInt32(arg0), ExploadTypeConverters.PrintBytes(arg1) }, true);
        }

        public IEnumerator Call(int arg0, byte[] arg1)
        {
            yield return SendRequest("TransferArtefact", new string[] { ExploadTypeConverters.PrintInt32(arg0), ExploadTypeConverters.PrintBytes(arg1) }, false);
        }

        // Same as Call
        // Deprecated
        public IEnumerator TransferArtefact(int arg0, byte[] arg1)
        {
            yield return SendRequest("TransferArtefact", new string[] { ExploadTypeConverters.PrintInt32(arg0), ExploadTypeConverters.PrintBytes(arg1) }, false);
        }
    }
}