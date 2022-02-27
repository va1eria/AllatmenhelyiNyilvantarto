ALTER TABLE [Allat] ADD PRIMARY KEY ([Nev])
ALTER TABLE [Orokbefogado] ADD PRIMARY KEY ([Id])

ALTER TABLE [Orokbefogadas] ADD CONSTRAINT [Orokbefogadas_Allat_FK] FOREIGN KEY ([AllatID]) REFERENCES [Allat]([Nev]);
ALTER TABLE [Orokbefogadas] ADD CONSTRAINT [Orokbefogadas_Orokbefogado_FK] FOREIGN KEY ([OrokbefogadoID]) REFERENCES [Orokbefogado]([Id]);

ALTER TABLE [Allat] ADD [GondozoID] INT NULL;
ALTER TABLE [Allat] ADD CONSTRAINT [Allat_Gondozo_FK] FOREIGN KEY ([GondozoID]) REFERENCES [Gondozo]([Id]);
