namespace Expload {

    using Pravda;
    using System;

    [Program]
    public class CryptoBattleProgram {

        public Mapping<int, Bytes> ArtefactToOwner;
        public int ArtefactId;
        public static void Main() { }

        public Bytes ServerAddress;
        public CryptoBattleProgram()
        {
            ServerAddress = Info.Sender();
            ArtefactId = 1;
            ArtefactToOwner = new Mapping<int, Bytes>();
        }

        public void CreateArtefact(Bytes address)
        {
            if (ServerAddress != Info.Sender())
                Error.Throw("Only server can create artefact. Owner ID {ServerAddress}, Sender {Info.Sender()}");
            ArtefactId = ArtefactId + 1;
            ArtefactToOwner.put(ArtefactId, address);
        }

        public void TransferArtefact(Bytes from, Bytes to, int artefactId)
        {
            if (ServerAddress != Info.Sender())
                Error.Throw("Only server can transfer artefact. Owner ID {ServerAddress}, Sender {Info.Sender()}");

            if (ArtefactToOwner.get(artefactId) == from)
            {
                ArtefactToOwner.put(artefactId, to);
            }
        }

        public Bytes GetOwner(int artefactId){
            return ArtefactToOwner.get(artefactId);
        }

        //public string GetServerAddress()
        //{
        //    return ServerAddress.ToString();
        //}

        //public string GetCurrentArtefactId()
        //{
        //    return ArtefactId.ToString();
        //}

        //public long GetBalanceOf(Bytes address)
        //{
        //    return Info.Balance(address);
        //}
    }
}
