-- 이익(Profits) 테이블 
CREATE TABLE [dbo].[Profits]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1, 1),
	ParentId Int Not Null,
	[Order] Int Not Null,
	Sale Float Null,
	Cost Float Null,
	Quantity Int Null,
	Profit Float Null
)
Go
