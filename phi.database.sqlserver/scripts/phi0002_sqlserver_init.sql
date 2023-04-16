-- COPYRIGHT 2014-2016 Anton Yarkov
-- Email: anton.yarkov@gmail.com
-- Skype: optiklab

-----------------------------------------------------------------


INSERT INTO [dbo].[Roles] ([Name],[Active]) VALUES ('Administrators', 1)
INSERT INTO [dbo].[Roles] ([Name],[Active]) VALUES ('Registered', 1)
INSERT INTO [dbo].[Roles] ([Name],[Active]) VALUES ('Developers', 1)
INSERT INTO [dbo].[Roles] ([Name],[Active]) VALUES ('Guests', 1)
INSERT INTO [dbo].[Roles] ([Name],[Active]) VALUES ('DataProvider', 1)
INSERT INTO [dbo].[Roles] ([Name],[Active]) VALUES ('Not activated', 1)
GO


SET IDENTITY_INSERT [dbo].[Language] ON
INSERT INTO [dbo].[Language] ([Id],[Code],[Fullname]) VALUES (1,'en','English')
INSERT INTO [dbo].[Language] ([Id],[Code],[Fullname]) VALUES (2,'ru','Russian')
SET IDENTITY_INSERT [dbo].[Language] OFF

GO


INSERT INTO [dbo].[EmailAccount] ([Email],[DisplayName],[Host],[Port],[Username],[Password],[EnableSsl],[UseDefaultCredentials])
     VALUES ('cleverwearer@gmail.com', 'Admin', '', 995, 'cleverwearer@gmail.com', '@KeepInTouch1', 0, 1)
INSERT INTO [dbo].[EmailAccount] ([Email],[DisplayName],[Host],[Port],[Username],[Password],[EnableSsl],[UseDefaultCredentials])
     VALUES ('cleverwearer@gmail.com', 'RegisterdUsers', '', 995, 'cleverwearer@gmail.com', '@KeepInTouch1', 0, 1)
INSERT INTO [dbo].[EmailAccount] ([Email],[DisplayName],[Host],[Port],[Username],[Password],[EnableSsl],[UseDefaultCredentials])
     VALUES ('cleverwearer@gmail.com', 'Support', '', 995, 'cleverwearer@gmail.com', '@KeepInTouch1', 0, 1)
GO


INSERT INTO [dbo].[MessageTemplate] ([Name],[BccEmailAddresses],[Subject],[Body],[IsActive],[EmailAccountId])
     VALUES ( 'AccountActivation', '', 'Account activation on Clever Wearer', 'Hello, {0}! Please go to link {1} to activate your account.', 1, 3)
INSERT INTO [dbo].[MessageTemplate] ([Name],[BccEmailAddresses],[Subject],[Body],[IsActive],[EmailAccountId])
     VALUES ( 'WelcomeMessage', '', 'Welcome to Clever Wearer', 'You are welcome on Clever Wearer, {0}! Now you can create your own cloakroom and have comfort cloth every day!', 1, 3)
INSERT INTO [dbo].[MessageTemplate] ([Name],[BccEmailAddresses],[Subject],[Body],[IsActive],[EmailAccountId])
     VALUES ( 'PasswordRecovery', '', 'Password recovery on Clever Wearer', 'Hi, {0}. Go to link {1} to create new password.', 1, 3)
GO

INSERT INTO [dbo].[Setting] ([Name],[Value]) VALUES ('Media.Images.AvatarPictureSize', '85')
INSERT INTO [dbo].[Setting] ([Name],[Value]) VALUES ('Media.Images.ProductThumbPictureSize', '125')
INSERT INTO [dbo].[Setting] ([Name],[Value]) VALUES ('Media.Images.ProductDetailsPictureSize', '300')
INSERT INTO [dbo].[Setting] ([Name],[Value]) VALUES ('Media.Images.ProductThumbPictureSizeOnProductDetailsPage', '70')
INSERT INTO [dbo].[Setting] ([Name],[Value]) VALUES ('Media.Images.ProductVariantPictureSize', '125')
INSERT INTO [dbo].[Setting] ([Name],[Value]) VALUES ('Media.Images.CategoryThumbPictureSize', '125')
INSERT INTO [dbo].[Setting] ([Name],[Value]) VALUES ('Media.Images.ManufacturerThumbPictureSize', '125')
INSERT INTO [dbo].[Setting] ([Name],[Value]) VALUES ('Media.Images.CartThumbPictureSize', '80')
INSERT INTO [dbo].[Setting] ([Name],[Value]) VALUES ('Media.Images.MaximumImageSize', '1280')
INSERT INTO [dbo].[Setting] ([Name],[Value]) VALUES ('Media.Images.DefaultPictureZoomEnabled', 'false')
GO

INSERT INTO [dbo].[GoodThoughts] ([LanguageId],[Author],[Description]) VALUES (1,'Tommy Dewar','Do nothing, be nothing, say nothing and you will avoid criticism.')
INSERT INTO [dbo].[GoodThoughts] ([LanguageId],[Author],[Description]) VALUES (1,'Eleanor Roosevelt','Great minds discuss ideas.<br />Average minds discuss events.<br />Small minds discuss people.')
INSERT INTO [dbo].[GoodThoughts] ([LanguageId],[Author],[Description]) VALUES (1,'Neil deGrasse Tyson','The good thing about science is that it’s true whether or not you believe in it')
INSERT INTO [dbo].[GoodThoughts] ([LanguageId],[Author],[Description]) VALUES (1,'Murphy''s law','Anything that can go wrong will go wrong.')
INSERT INTO [dbo].[GoodThoughts] ([LanguageId],[Author],[Description]) VALUES (1,'Sturgeon''s Law','Nothing is always absolutely so')
INSERT INTO [dbo].[GoodThoughts] ([LanguageId],[Author],[Description]) VALUES (1,'The “duck test”','If it looks like a duck, swims like a duck, and quacks like a duck, then it probably is a duck.')
INSERT INTO [dbo].[GoodThoughts] ([LanguageId],[Author],[Description]) VALUES (2,'Закон Парето','20 % усилий дают 80 % результата, а остальные 80 % усилий — лишь 20 % результата')
INSERT INTO [dbo].[GoodThoughts] ([LanguageId],[Author],[Description]) VALUES (2,'Закон Паркинсона','Работа заполняет время, отпущенное на неё')
INSERT INTO [dbo].[GoodThoughts] ([LanguageId],[Author],[Description]) VALUES (2,'Отто Фон Бисмарк','Никогда не врут так, как во время войны, после охоты и перед выборами')
INSERT INTO [dbo].[GoodThoughts] ([LanguageId],[Author],[Description]) VALUES (2,'Томми Дюар','Ничего не делай, ничего не говори, и тогда ты избежишь критики')
INSERT INTO [dbo].[GoodThoughts] ([LanguageId],[Author],[Description]) VALUES (2,'Брюс Ли','Освободите свой разум, станьте бесформенными, текучими и изменчивыми, как вода. Если вы нальете воду в кружку, она станет кружкой, если перельете в бутылку, она станет бутылкой, если нальете в чайник — она станет чайником. Вода может течь, но может и сокрушать. Стань водой, мой друг.')
INSERT INTO [dbo].[GoodThoughts] ([LanguageId],[Author],[Description]) VALUES (2,'Льюис Кэрол, Алиса в Стране Чудес','Нужно делать так, как нужно. А как не нужно, делать не нужно!')
INSERT INTO [dbo].[GoodThoughts] ([LanguageId],[Author],[Description]) VALUES (2,'Льюис Кэрол, Алиса в Стране Чудес','Нужно бежать со всех ног, чтобы только оставаться на месте, а чтобы куда-то попасть, надо бежать как минимум вдвое быстрее!')
INSERT INTO [dbo].[GoodThoughts] ([LanguageId],[Author],[Description]) VALUES (2,'Льюис Кэрол, Алиса в Стране Чудес','Если бы это было так, это бы еще ничего, а если бы ничего, оно бы так и было, но так как это не так, так оно и не этак! Такова логика вещей!')
INSERT INTO [dbo].[GoodThoughts] ([LanguageId],[Author],[Description]) VALUES (2,'Льюис Кэрол, Алиса в Стране Чудес','Одна из самых серьезных потерь в битве — это потеря головы.')
INSERT INTO [dbo].[GoodThoughts] ([LanguageId],[Author],[Description]) VALUES (2,'Льюис Кэрол, Алиса в Стране Чудес','Сначала раздай всем пирога, а потом разрежь его!')
INSERT INTO [dbo].[GoodThoughts] ([LanguageId],[Author],[Description]) VALUES (2,'Льюис Кэрол, Алиса в Стране Чудес','От перца, верно, начинают всем перечить. От уксуса — куксятся, от горчицы — огорчаются, от лука — лукавят, от вина — винятся, а от сдобы — добреют. Как жалко, что никто об этом не знает... Все было бы так просто. Ели бы сдобу — и добрели!')
INSERT INTO [dbo].[GoodThoughts] ([LanguageId],[Author],[Description]) VALUES (2,'Льюис Кэрол, Алиса в Стране Чудес','Никогда не думай, что ты иная, чем могла бы быть иначе, чем будучи иной в тех случаях, когда иначе нельзя не быть.')
INSERT INTO [dbo].[GoodThoughts] ([LanguageId],[Author],[Description]) VALUES (2,'Льюис Кэрол, Алиса в Стране Чудес','Отсюда мораль: что-то не соображу.')
--INSERT INTO [dbo].[GoodThoughts] ([LanguageId],[Author],[Description]) VALUES (1,'','')

GO