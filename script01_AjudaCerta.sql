IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Agenda] (
    [Id] int NOT NULL IDENTITY,
    [Data] datetime2 NOT NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_Agenda] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Dinheiro] (
    [Id] int NOT NULL IDENTITY,
    [Valor] float NOT NULL,
    CONSTRAINT [PK_Dinheiro] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Doacao] (
    [Id] int NOT NULL IDENTITY,
    [Data] datetime2 NOT NULL,
    [StatusDoacao] int NOT NULL,
    [TipoDoacao] int NOT NULL,
    [IdDoacaoOrigem] int NOT NULL,
    CONSTRAINT [PK_Doacao] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Eletrodomestico] (
    [Id] int NOT NULL IDENTITY,
    [Medida] nvarchar(max) NULL,
    [Condicao] nvarchar(max) NULL,
    CONSTRAINT [PK_Eletrodomestico] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Endereco] (
    [Id] int NOT NULL IDENTITY,
    [Rua] nvarchar(max) NULL,
    [Numero] nvarchar(max) NULL,
    [Bairro] nvarchar(max) NULL,
    [Complemento] nvarchar(max) NULL,
    [Bloco] nvarchar(max) NULL,
    [Cidade] nvarchar(max) NULL,
    [Estado] nvarchar(max) NULL,
    [Cep] nvarchar(max) NULL,
    CONSTRAINT [PK_Endereco] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ItemDoacao] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Descricao] nvarchar(max) NULL,
    CONSTRAINT [PK_ItemDoacao] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Mobilia] (
    [Id] int NOT NULL IDENTITY,
    [Tipo] nvarchar(max) NULL,
    [Medida] nvarchar(max) NULL,
    [Condicao] nvarchar(max) NULL,
    CONSTRAINT [PK_Mobilia] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Produto] (
    [Id] int NOT NULL IDENTITY,
    [Validade] datetime2 NOT NULL,
    [TipoProduto] int NOT NULL,
    CONSTRAINT [PK_Produto] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Roupa] (
    [Id] int NOT NULL IDENTITY,
    [Tamanho] nvarchar(max) NULL,
    [Condicao] nvarchar(max) NULL,
    [Genero] int NOT NULL,
    [FaixaEtaria] int NOT NULL,
    CONSTRAINT [PK_Roupa] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Usuario] (
    [Id] int NOT NULL IDENTITY,
    [Email] nvarchar(max) NULL,
    [Senha_Hash] varbinary(max) NULL,
    [Senha_Salt] varbinary(max) NULL,
    [UltimoAcesso] datetime2 NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Pessoa] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Documento] nvarchar(max) NULL,
    [Telefone] nvarchar(max) NULL,
    [Genero] nvarchar(max) NULL,
    [DataNasc] datetime2 NOT NULL,
    [Tipo] int NOT NULL,
    [UsuarioId] int NULL,
    CONSTRAINT [PK_Pessoa] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pessoa_Usuario_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuario] ([Id])
);
GO

CREATE INDEX [IX_Pessoa_UsuarioId] ON [Pessoa] ([UsuarioId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230920011012_InitialCreate', N'7.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Pessoa] ADD [EnderecoId] int NULL;
GO

CREATE INDEX [IX_Pessoa_EnderecoId] ON [Pessoa] ([EnderecoId]);
GO

ALTER TABLE [Pessoa] ADD CONSTRAINT [FK_Pessoa_Endereco_EnderecoId] FOREIGN KEY ([EnderecoId]) REFERENCES [Endereco] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230920012008_MigracaoEndereco', N'7.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Agenda] ADD [EnderecoId] int NULL;
GO

ALTER TABLE [Agenda] ADD [PessoaId] int NULL;
GO

CREATE INDEX [IX_Agenda_EnderecoId] ON [Agenda] ([EnderecoId]);
GO

CREATE INDEX [IX_Agenda_PessoaId] ON [Agenda] ([PessoaId]);
GO

ALTER TABLE [Agenda] ADD CONSTRAINT [FK_Agenda_Endereco_EnderecoId] FOREIGN KEY ([EnderecoId]) REFERENCES [Endereco] ([Id]);
GO

ALTER TABLE [Agenda] ADD CONSTRAINT [FK_Agenda_Pessoa_PessoaId] FOREIGN KEY ([PessoaId]) REFERENCES [Pessoa] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230920012356_MigracaoAgenda', N'7.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Doacao] ADD [AgendaId] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Doacao] ADD [DinheiroId] int NULL;
GO

ALTER TABLE [Doacao] ADD [PessoaId] int NULL;
GO

CREATE UNIQUE INDEX [IX_Doacao_AgendaId] ON [Doacao] ([AgendaId]);
GO

CREATE INDEX [IX_Doacao_DinheiroId] ON [Doacao] ([DinheiroId]);
GO

CREATE INDEX [IX_Doacao_PessoaId] ON [Doacao] ([PessoaId]);
GO

ALTER TABLE [Doacao] ADD CONSTRAINT [FK_Doacao_Agenda_AgendaId] FOREIGN KEY ([AgendaId]) REFERENCES [Agenda] ([Id]) ON DELETE CASCADE;
GO

ALTER TABLE [Doacao] ADD CONSTRAINT [FK_Doacao_Dinheiro_DinheiroId] FOREIGN KEY ([DinheiroId]) REFERENCES [Dinheiro] ([Id]);
GO

ALTER TABLE [Doacao] ADD CONSTRAINT [FK_Doacao_Pessoa_PessoaId] FOREIGN KEY ([PessoaId]) REFERENCES [Pessoa] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230920013206_MigracaoDoacao', N'7.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Roupa] ADD [ItemDoacaoId] int NULL;
GO

ALTER TABLE [Produto] ADD [ItemDoacaoId] int NULL;
GO

ALTER TABLE [Mobilia] ADD [ItemDoacaoId] int NULL;
GO

ALTER TABLE [Eletrodomestico] ADD [ItemDoacaoId] int NULL;
GO

CREATE INDEX [IX_Roupa_ItemDoacaoId] ON [Roupa] ([ItemDoacaoId]);
GO

CREATE INDEX [IX_Produto_ItemDoacaoId] ON [Produto] ([ItemDoacaoId]);
GO

CREATE INDEX [IX_Mobilia_ItemDoacaoId] ON [Mobilia] ([ItemDoacaoId]);
GO

CREATE INDEX [IX_Eletrodomestico_ItemDoacaoId] ON [Eletrodomestico] ([ItemDoacaoId]);
GO

ALTER TABLE [Eletrodomestico] ADD CONSTRAINT [FK_Eletrodomestico_ItemDoacao_ItemDoacaoId] FOREIGN KEY ([ItemDoacaoId]) REFERENCES [ItemDoacao] ([Id]);
GO

ALTER TABLE [Mobilia] ADD CONSTRAINT [FK_Mobilia_ItemDoacao_ItemDoacaoId] FOREIGN KEY ([ItemDoacaoId]) REFERENCES [ItemDoacao] ([Id]);
GO

ALTER TABLE [Produto] ADD CONSTRAINT [FK_Produto_ItemDoacao_ItemDoacaoId] FOREIGN KEY ([ItemDoacaoId]) REFERENCES [ItemDoacao] ([Id]);
GO

ALTER TABLE [Roupa] ADD CONSTRAINT [FK_Roupa_ItemDoacao_ItemDoacaoId] FOREIGN KEY ([ItemDoacaoId]) REFERENCES [ItemDoacao] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230920015536_MigracaoItemDoacao', N'7.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [ItemDoacaoDoado] (
    [DoacaoId] int NOT NULL,
    [ItemDoacaoId] int NOT NULL,
    CONSTRAINT [PK_ItemDoacaoDoado] PRIMARY KEY ([DoacaoId], [ItemDoacaoId]),
    CONSTRAINT [FK_ItemDoacaoDoado_Doacao_DoacaoId] FOREIGN KEY ([DoacaoId]) REFERENCES [Doacao] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ItemDoacaoDoado_ItemDoacao_ItemDoacaoId] FOREIGN KEY ([ItemDoacaoId]) REFERENCES [ItemDoacao] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_ItemDoacaoDoado_ItemDoacaoId] ON [ItemDoacaoDoado] ([ItemDoacaoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230920020258_MigracaoItemDoacaoDoado', N'7.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Pessoa] ADD [fisicaJuridica] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230923130804_MigracaoPessoaFisicaJuridica', N'7.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Senha_Hash', N'Senha_Salt', N'UltimoAcesso') AND [object_id] = OBJECT_ID(N'[Usuario]'))
    SET IDENTITY_INSERT [Usuario] ON;
INSERT INTO [Usuario] ([Id], [Email], [Senha_Hash], [Senha_Salt], [UltimoAcesso])
VALUES (1, N'fuscatcc@gmail.com', 0x432C3C955080FDD80069E3B2F3DD1D9F30F115E0008D11912B38F78999C3547AFAC8CB686D1B86BE9A4E983F147E352D6FFD9D632E39EFE2105AB3FE0DB0E8BB, 0xC331B729EC0CE45F6DBCF73E45F6606FBCFFC85EC237393F5E7FBEE6DFDDC25063D7C4D157A391E2B464890D83F02D0918B062FCDBC1969447D8E9FF02B7F2CBE400FA5DADC303DB46EAB1CF77D4140C8BFA2487D2C471CB1B155FDF12897B200637C90B2D9A38DF0F9F09E6363B3960BA1EC8134E26E8FC6E9A585A563A1ED2, '0001-01-01T00:00:00.0000000');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Senha_Hash', N'Senha_Salt', N'UltimoAcesso') AND [object_id] = OBJECT_ID(N'[Usuario]'))
    SET IDENTITY_INSERT [Usuario] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230924144937_MigracaoUsuario', N'7.0.11');
GO

COMMIT;
GO

