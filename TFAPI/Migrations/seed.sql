USE [TFAPI.Providers.APIDbContext];

SET IDENTITY_INSERT [dbo].[Currencies] ON
INSERT INTO [dbo].[Currencies] ([Id], [Name], [Surcharge]) VALUES (1, N'ZAR', 0)
INSERT INTO [dbo].[Currencies] ([Id], [Name], [Surcharge]) VALUES (2, N'USD', 7.5)
INSERT INTO [dbo].[Currencies] ([Id], [Name], [Surcharge]) VALUES (3, N'GBP', 5)
INSERT INTO [dbo].[Currencies] ([Id], [Name], [Surcharge]) VALUES (4, N'EUR', 5)
INSERT INTO [dbo].[Currencies] ([Id], [Name], [Surcharge]) VALUES (5, N'KES', 2.5)
SET IDENTITY_INSERT [dbo].[Currencies] OFF

SET IDENTITY_INSERT [dbo].[CurrencyActions] ON
INSERT INTO [dbo].[CurrencyActions] ([Id], [CurrencyId], [Key], [Value]) VALUES (1, 4, N'Discount', N'2')
SET IDENTITY_INSERT [dbo].[CurrencyActions] OFF

INSERT INTO [dbo].[ExchangeRates] ([LocalCurrency], [ForeignCurrency], [Rate], [UpdateDateTime]) VALUES (1, 2, 0.0808279, N'2019-05-23 00:16:12')
INSERT INTO [dbo].[ExchangeRates] ([LocalCurrency], [ForeignCurrency], [Rate], [UpdateDateTime]) VALUES (1, 3, 0.0527032, N'2019-05-27 00:00:00')
INSERT INTO [dbo].[ExchangeRates] ([LocalCurrency], [ForeignCurrency], [Rate], [UpdateDateTime]) VALUES (1, 4, 0.071871, N'2019-05-27 00:00:00')
INSERT INTO [dbo].[ExchangeRates] ([LocalCurrency], [ForeignCurrency], [Rate], [UpdateDateTime]) VALUES (1, 5, 7.81498, N'2019-05-27 00:00:00')