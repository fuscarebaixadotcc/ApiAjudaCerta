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
    [TipoItem] int NOT NULL,
    [Foto] varbinary(max) NULL,
    CONSTRAINT [PK_ItemDoacao] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Post] (
    [Id] int NOT NULL IDENTITY,
    [Conteudo] nvarchar(max) NULL,
    [Foto] varbinary(max) NULL,
    [DataPostagem] datetime2 NOT NULL,
    [Likes] int NOT NULL,
    CONSTRAINT [PK_Post] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Usuario] (
    [Id] int NOT NULL IDENTITY,
    [Email] nvarchar(max) NULL,
    [Senha_Hash] varbinary(max) NULL,
    [Senha_Salt] varbinary(max) NULL,
    [UltimoAcesso] datetime2 NOT NULL,
    [Foto] varbinary(max) NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Eletrodomestico] (
    [Id] int NOT NULL IDENTITY,
    [Medida] nvarchar(max) NULL,
    [Condicao] nvarchar(max) NULL,
    [StatusItem] int NOT NULL,
    [ItemDoacaoId] int NULL,
    CONSTRAINT [PK_Eletrodomestico] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Eletrodomestico_ItemDoacao_ItemDoacaoId] FOREIGN KEY ([ItemDoacaoId]) REFERENCES [ItemDoacao] ([Id])
);
GO

CREATE TABLE [Mobilia] (
    [Id] int NOT NULL IDENTITY,
    [Tipo] nvarchar(max) NULL,
    [Medida] nvarchar(max) NULL,
    [Condicao] nvarchar(max) NULL,
    [StatusItem] int NOT NULL,
    [ItemDoacaoId] int NULL,
    CONSTRAINT [PK_Mobilia] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Mobilia_ItemDoacao_ItemDoacaoId] FOREIGN KEY ([ItemDoacaoId]) REFERENCES [ItemDoacao] ([Id])
);
GO

CREATE TABLE [Produto] (
    [Id] int NOT NULL IDENTITY,
    [Validade] datetime2 NOT NULL,
    [TipoProduto] int NOT NULL,
    [StatusItem] int NOT NULL,
    [ItemDoacaoId] int NULL,
    CONSTRAINT [PK_Produto] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Produto_ItemDoacao_ItemDoacaoId] FOREIGN KEY ([ItemDoacaoId]) REFERENCES [ItemDoacao] ([Id])
);
GO

CREATE TABLE [Roupa] (
    [Id] int NOT NULL IDENTITY,
    [Tamanho] nvarchar(max) NULL,
    [Condicao] nvarchar(max) NULL,
    [Genero] int NOT NULL,
    [FaixaEtaria] int NOT NULL,
    [StatusItem] int NOT NULL,
    [ItemDoacaoId] int NULL,
    CONSTRAINT [PK_Roupa] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Roupa_ItemDoacao_ItemDoacaoId] FOREIGN KEY ([ItemDoacaoId]) REFERENCES [ItemDoacao] ([Id])
);
GO

CREATE TABLE [Pessoa] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Documento] nvarchar(max) NULL,
    [fisicaJuridica] int NOT NULL,
    [Telefone] nvarchar(max) NULL,
    [Genero] nvarchar(max) NULL,
    [DataNasc] datetime2 NOT NULL,
    [Tipo] int NOT NULL,
    [UsuarioId] int NULL,
    [EnderecoId] int NULL,
    CONSTRAINT [PK_Pessoa] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pessoa_Endereco_EnderecoId] FOREIGN KEY ([EnderecoId]) REFERENCES [Endereco] ([Id]),
    CONSTRAINT [FK_Pessoa_Usuario_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuario] ([Id])
);
GO

CREATE TABLE [Agenda] (
    [Id] int NOT NULL IDENTITY,
    [Data] datetime2 NOT NULL,
    [Status] int NOT NULL,
    [PessoaId] int NULL,
    [EnderecoId] int NULL,
    CONSTRAINT [PK_Agenda] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Agenda_Endereco_EnderecoId] FOREIGN KEY ([EnderecoId]) REFERENCES [Endereco] ([Id]),
    CONSTRAINT [FK_Agenda_Pessoa_PessoaId] FOREIGN KEY ([PessoaId]) REFERENCES [Pessoa] ([Id])
);
GO

CREATE TABLE [Mensagem] (
    [Id] int NOT NULL IDENTITY,
    [Conteudo] nvarchar(max) NULL,
    [DataEnvio] datetime2 NOT NULL,
    [DestinatarioId] int NOT NULL,
    [RemetenteId] int NOT NULL,
    CONSTRAINT [PK_Mensagem] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Mensagem_Pessoa_DestinatarioId] FOREIGN KEY ([DestinatarioId]) REFERENCES [Pessoa] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Mensagem_Pessoa_RemetenteId] FOREIGN KEY ([RemetenteId]) REFERENCES [Pessoa] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Doacao] (
    [Id] int NOT NULL IDENTITY,
    [Data] datetime2 NOT NULL,
    [StatusDoacao] int NOT NULL,
    [TipoDoacao] int NOT NULL,
    [IdDoacaoOrigem] int NOT NULL,
    [PessoaId] int NULL,
    [AgendaId] int NOT NULL,
    [Dinheiro] float NOT NULL,
    CONSTRAINT [PK_Doacao] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Doacao_Agenda_AgendaId] FOREIGN KEY ([AgendaId]) REFERENCES [Agenda] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Doacao_Pessoa_PessoaId] FOREIGN KEY ([PessoaId]) REFERENCES [Pessoa] ([Id])
);
GO

CREATE TABLE [ItemDoacaoDoado] (
    [DoacaoId] int NOT NULL,
    [ItemDoacaoId] int NOT NULL,
    CONSTRAINT [PK_ItemDoacaoDoado] PRIMARY KEY ([DoacaoId], [ItemDoacaoId]),
    CONSTRAINT [FK_ItemDoacaoDoado_Doacao_DoacaoId] FOREIGN KEY ([DoacaoId]) REFERENCES [Doacao] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ItemDoacaoDoado_ItemDoacao_ItemDoacaoId] FOREIGN KEY ([ItemDoacaoId]) REFERENCES [ItemDoacao] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Bairro', N'Bloco', N'Cep', N'Cidade', N'Complemento', N'Estado', N'Numero', N'Rua') AND [object_id] = OBJECT_ID(N'[Endereco]'))
    SET IDENTITY_INSERT [Endereco] ON;
INSERT INTO [Endereco] ([Id], [Bairro], [Bloco], [Cep], [Cidade], [Complemento], [Estado], [Numero], [Rua])
VALUES (1, N'Jardim Tremembé', NULL, N'02319000', N'São Paulo', NULL, N'São Paulo', N'1091', N'Avenida Josino Vieira de Goes');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Bairro', N'Bloco', N'Cep', N'Cidade', N'Complemento', N'Estado', N'Numero', N'Rua') AND [object_id] = OBJECT_ID(N'[Endereco]'))
    SET IDENTITY_INSERT [Endereco] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataNasc', N'Documento', N'EnderecoId', N'Genero', N'Nome', N'Telefone', N'Tipo', N'UsuarioId', N'fisicaJuridica') AND [object_id] = OBJECT_ID(N'[Pessoa]'))
    SET IDENTITY_INSERT [Pessoa] ON;
INSERT INTO [Pessoa] ([Id], [DataNasc], [Documento], [EnderecoId], [Genero], [Nome], [Telefone], [Tipo], [UsuarioId], [fisicaJuridica])
VALUES (1, '0001-01-01T00:00:00.0000000', NULL, NULL, NULL, N'ONG Estrela Dalva', NULL, 2, NULL, 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataNasc', N'Documento', N'EnderecoId', N'Genero', N'Nome', N'Telefone', N'Tipo', N'UsuarioId', N'fisicaJuridica') AND [object_id] = OBJECT_ID(N'[Pessoa]'))
    SET IDENTITY_INSERT [Pessoa] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Foto', N'Senha_Hash', N'Senha_Salt', N'UltimoAcesso') AND [object_id] = OBJECT_ID(N'[Usuario]'))
    SET IDENTITY_INSERT [Usuario] ON;
INSERT INTO [Usuario] ([Id], [Email], [Foto], [Senha_Hash], [Senha_Salt], [UltimoAcesso])
VALUES (1, N'ongestreladalva@gmail.com', NULL, 0x14AB119055A4F2AA453BDEFDF7F26BF2C82C50B2951E653743C2B313F457082EA22F4B441CF229FBB05748E5C9207B8985ACC9F6EE290B39FA3E66CBD7BE6580, 0x9E6460527A254CC9206925DB33F3E4530862225EA0862471AF3A152E97B1E3AB842584BBABC8431CC93473929C141D7F989CF1DCC964712FF7B2BAAE9139C0561A8E6DE22ABCA512AF01AE7690D62A0267379E9270625376D8EE9D17777F837EF5928B44BFCA26E74E4EB5D8EEB3693F95A952E37FC76BBB42A84D6D7BD91028, '0001-01-01T00:00:00.0000000');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Foto', N'Senha_Hash', N'Senha_Salt', N'UltimoAcesso') AND [object_id] = OBJECT_ID(N'[Usuario]'))
    SET IDENTITY_INSERT [Usuario] OFF;
GO

CREATE INDEX [IX_Agenda_EnderecoId] ON [Agenda] ([EnderecoId]);
GO

CREATE INDEX [IX_Agenda_PessoaId] ON [Agenda] ([PessoaId]);
GO

CREATE UNIQUE INDEX [IX_Doacao_AgendaId] ON [Doacao] ([AgendaId]);
GO

CREATE INDEX [IX_Doacao_PessoaId] ON [Doacao] ([PessoaId]);
GO

CREATE INDEX [IX_Eletrodomestico_ItemDoacaoId] ON [Eletrodomestico] ([ItemDoacaoId]);
GO

CREATE INDEX [IX_ItemDoacaoDoado_ItemDoacaoId] ON [ItemDoacaoDoado] ([ItemDoacaoId]);
GO

CREATE INDEX [IX_Mensagem_DestinatarioId] ON [Mensagem] ([DestinatarioId]);
GO

CREATE INDEX [IX_Mensagem_RemetenteId] ON [Mensagem] ([RemetenteId]);
GO

CREATE INDEX [IX_Mobilia_ItemDoacaoId] ON [Mobilia] ([ItemDoacaoId]);
GO

CREATE INDEX [IX_Pessoa_EnderecoId] ON [Pessoa] ([EnderecoId]);
GO

CREATE INDEX [IX_Pessoa_UsuarioId] ON [Pessoa] ([UsuarioId]);
GO

CREATE INDEX [IX_Produto_ItemDoacaoId] ON [Produto] ([ItemDoacaoId]);
GO

CREATE INDEX [IX_Roupa_ItemDoacaoId] ON [Roupa] ([ItemDoacaoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231119175714_InitialCreate', N'7.0.11');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Pessoa] ADD [Username] nvarchar(max) NULL;
GO

UPDATE [Pessoa] SET [Username] = NULL
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuario] SET [Senha_Hash] = 0x91881FA9ECD443CF34649BA5B091F0D1C71EC8CC188D6F7D30C2A203F2E2A0EDF8D82FEB9BBEA5ADE9DE25EA41E92324EEBF662FDD41C42052D40E14E864FCB5, [Senha_Salt] = 0xACAF5509AC41716A81C0F78FC808711753DF9ADCCC80A304AFE0CFE5FF63CD7B4C70ADCEB0C69B72A016E32AE0FF9B6F37D03454161B3D625FE26F6F35A68DFE5FA21979D54B9B7223752D09D7CD96C6C8F607FF739CD770A8074F1519F68E46257BBCDDCB12894F84B62E1AC41F21A219A877B5F183A349499519BFEE3D1B8D
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231120152822_MigracaoNomeUsuario', N'7.0.11');
GO

COMMIT;
GO

