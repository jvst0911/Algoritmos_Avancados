#include <stdio.h>;
#include <conio2.h>;

using namespace std;

struct ELEMENTO
{
    int idade;
    ELEMENTO *proximo;
};

main()
{
    ELEMENTO inicio = NULL;

    while (true)
    {
        clrscr();

        gotoxy(10, 1);
        cout << "-= Menu =-";
        gotoxy(10, 2);
        cout << "1 - Incluir elementos";
        gotoxy(10, 3);
        cout << "2 - Apagar elementos";
        gotoxy(10, 4);
        cout << "3 - Listar elementos";
        gotoxy(10, 5);
        cout << "0 - Sair";
        gotoxy(10, 6);
        cout << "Opcao: ";
        cin >> op;

        if (op == 0)
            break;

        if (op == 1)
        {
            int id;
            gotoxy(20, 8);
            cout << "Novo elemento";
            gotoxy(20, 9);
            cout << "Idade: ";
            cin >> id;

            // Cria novo elemento
            ELEMENTO *novo = new ELEMENTO();
            novo->idade = id;

            // incluir elemento na memoria
            novo->proximo = inicio;
            inicio = novo;
        }

        if (op == 2)
        {
            gotoxy(20, 8);
            cout << "Apagar elemento";
            gotoxy(20, 9);
            cout << "Elemento " << inicio->idade;

            ELEMENTO *aux = inicio;
            inicio = inicio->proximo;
            delete aux;
            getch();
        }

        if (op == 3)
        {
            gotoxy(20, 8);
            cout << "Listando elementos";

            gotoxy(20, 9);
            ELEMENTO *aux = inicio;

            while (aux != NULL)
            {
                cout << aux->idade << " - ";
                aux = aux->proximo;
            }
        }

        getch();
    };
}