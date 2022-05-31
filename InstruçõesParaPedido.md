1- Rodar o comando: Add-migration e em seguida o comando: update Database (Banco de dados utilizado: SQLServer)
Obs: verificar string de conexão com o banco de dados na classe 'DataContext'


2- Primeiro deve inserir um endereco

3- Depois deve inserir um cliente

4- Em seguida, insira como deseja a boneca:
    Cabelo:    
        StraightBlack = 0,
        BlackCurly = 1,
        StraightRed = 2,
        CurlyRed = 3,
        StraightBlonde = 4,
        CurlyBlonde = 5,
        StraightBrown = 6,
        CurlyBrown = 7

    Olhos: 
        Blue = 0,
        Green = 1,
        Brown = 2

    Pele: 
         Clear = 0,
        Medium = 1,
        Dark = 2

    Roupa:
        Dress = 0,
        ShirtAndSkirt = 1,
        ShirtAndPants = 2,
        BlouseAndShorts = 3
   
    Forma de Pagamento:
        Money = 0,
        Card = 1,
        Pix = 2

5- Após criar a boneca, crie o pedido inserindo o Id da boneca conforme sua escolha
