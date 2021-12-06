namespace TesteDeCasa.Utils
{
    class Constants
    {
        public const string InvalidValue = "Quatidade não pode ser null nem menor ou igual a zero";
        public const string NullAccount = "Conta não pode ser null";

        public const string NullId = "Id não pode ser null";
        public const string SameAccount = "Não é possível realizar operações para a mesma conta";
        
        public const string InvalidPin = "Senha deve conter seis digitos";

        public const string ExistingAccountCpf = "Duas contas não podem ter o mesmo Cpf";
        public const string ExistingAccountEmail = "Duas contas não podem ter o mesmo Email";
        public const string WrongPassword = "Senha incorreta";

        public const string InvalidAccountNumber = "Número da conta deve conter 10 digitos";

        public const string InvalidCpfCnpj = "Cpf/Cpnj inválido";

        public const string SuccessfulTransactionCreated = "Transação criada com sucesso";

        public const string InvalidReversal = "Só transferências podem ser revertidas";

        public const string SuccessfulTransactionFound = "Transação encontrada com sucesso";

        public const string InsufficienFunds = "Saldo insuficiente";

        public const string InvalidUser = "Usuário não tem permissão para esta operação";

        public const string RegexValidGuid =  @"[0-9a-fA-F]{8}-+(([0-9a-fA-F]{4}-){3})+[0-9a-fA-F]{12}?$";
        public const string RegexValidAccountNumber = @"^[0][1-9]\d{9}|^[1-9]\d{9}$";

    }
}