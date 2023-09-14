## :game_die: Архитектура API

<div align="center">

*pic coming soon*

</div>

Настроена JWT авторизация

Используется слоистая архитектура:

1) Controllers - эндпоинты и более ничего;
2) Services - бизнес-логика (самый жирный слой);
3) Repositories - sql-логика;
4) Context - контекст базы данных (таблицы)