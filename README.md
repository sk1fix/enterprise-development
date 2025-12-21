# 🚴 BikeRentalPoint - Система управления прокатом велосипедов

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-8.0-512BD4?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/apps/aspnet)
[![.NET Aspire](https://img.shields.io/badge/.NET%20Aspire-8.0-512BD4?style=flat-square&logo=dotnet)](https://learn.microsoft.com/dotnet/aspire/)
[![C#](https://img.shields.io/badge/C%23-12.0-239120?style=flat-square&logo=csharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![MySQL](https://img.shields.io/badge/MySQL-8.0-4479A1?style=flat-square&logo=mysql&logoColor=white)](https://www.mysql.com/)
[![Apache Kafka](https://img.shields.io/badge/Apache%20Kafka-3.6-231F20?style=flat-square&logo=apache-kafka)](https://kafka.apache.org/)
[![License](https://img.shields.io/badge/License-MIT-yellow.svg?style=flat-square)](LICENSE)

## 📋 О проекте

**BikeRentalPoint** - приложение для управления сервисом проката велосипедов. Проект реализован с использованием микросервисной архитектуры, Event-Driven подхода и современных технологий разработки на платформе .NET с оркестрацией через .NET Aspire.

Система предназначена для автоматизации процессов:
- Управления парком велосипедов
- Обработки заказов и бронирований
- Аналитики использования транспорта
- Генерации отчетов и статистики
- Асинхронной генерации данных через Kafka


### Слои приложения

```
┌─────────────────────────────────────────────────┐
│ Presentation Layer                              │
│ - BikeRentalPoint.Api.Host (REST API)           │
│ - Controllers, Middleware                       │
└─────────────────────────────────────────────────┘
                        ↓
┌─────────────────────────────────────────────────┐
│ Application Layer                               │
│ - BikeRentalPoint.Application                   │
│ - BikeRentalPoint.Application.Contracts         │
│ - Use Cases, DTOs, Services                     │
└─────────────────────────────────────────────────┘
                        ↓
┌─────────────────────────────────────────────────┐
│ Domain Layer                                    │
│ - BikeRentalPoint.Domain                        │
│ - Entities, Value Objects, Business Logic       │
└─────────────────────────────────────────────────┘
                        ↓
┌─────────────────────────────────────────────────┐
│ Infrastructure Layer                            │
│ - BikeRentalPoint.Infrastructure.EfCore         │
│ - BikeRentalPoint.Infrastructure.Kafka          │
│ - MySQL, Kafka, External APIs                   │
└─────────────────────────────────────────────────┘
```

## 🛠️ Технологический стек

### Backend & Infrastructure
- **Framework:** .NET 8.0
- **API:** ASP.NET Core Web API с поддержкой OpenAPI/Swagger
- **ORM:** Entity Framework Core 8.0
- **Database:** MySQL 8.0
- **Message Broker:** Apache Kafka 3.6 для асинхронной обработки событий
- **Orchestration:** .NET Aspire для оркестрации микросервисов
- **Testing:** xUnit для модульного тестирования
- **Data Generation:** Bogus для генерации тестовых данных
- **Mapping:** AutoMapper для маппинга объектов

### .NET Aspire Features
- ✅ **Service Discovery** - автоматическое обнаружение сервисов
- ✅ **Health Checks** - мониторинг состояния приложений
- ✅ **Distributed Tracing** - трассировка запросов между сервисами
- ✅ **Centralized Configuration** - централизованное управление конфигурацией
- ✅ **Dashboard** - встроенная панель мониторинга в реальном времени

### Архитектурные паттерны
- **Clean Architecture** - четкое разделение ответственности
- **Repository Pattern** - абстракция работы с данными
- **CQRS** - разделение команд и запросов
- **Dependency Injection** - инверсия зависимостей
- **Event-Driven Architecture** - асинхронная обработка через Kafka
- **Domain-Driven Design** - моделирование предметной области

## 📦 Структура решения

| Проект | Описание |
|--------|----------|
| **BikeRentalPoint.Api.Host** | REST API сервер с контроллерами и middleware |
| **BikeRentalPoint.AppHost** | Aspire orchestrator - точка входа для запуска всех сервисов |
| **BikeRentalPoint.Application** | Бизнес-логика и use cases |
| **BikeRentalPoint.Application.Contracts** | Контракты и DTO для API |
| **BikeRentalPoint.Domain** | Доменные модели |
| **BikeRentalPoint.Infrastructure.EfCore** | Реализация работы с БД MySQL через EF Core |
| **BikeRentalPoint.Infrastructure.Kafka** | Интеграция с Apache Kafka |
| **BikeRentalPoint.Generator.Kafka.Host** | Сервис генерации тестовых данных через Kafka |
| **BikeRentalPoint.ServiceDefaults** | Общие настройки для микросервисов Aspire |
| **BikeRentalPoint.Shared** | Общие утилиты и расширения |
| **BikeRentalPoint.Tests** | Модульные и интеграционные тесты |

## 🚀 Быстрый старт

### Предварительные требования

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop) (для MySQL и Kafka)
- IDE: [Visual Studio 2022](https://visualstudio.microsoft.com/) / [JetBrains Rider](https://www.jetbrains.com/rider/) / [VS Code](https://code.visualstudio.com/)
- [.NET Aspire Workload](https://learn.microsoft.com/dotnet/aspire/fundamentals/setup-tooling)

### Установка .NET Aspire Workload
```bash
dotnet workload update

dotnet workload install aspire
```

### Установка и запуск

1. **Клонируйте репозиторий:**
```bash
git clone https://github.com/sk1fix/enterprise-development.git

cd enterprise-development
```

2. **Восстановите зависимости:**
```bash
dotnet restore BikeRentalPoint.sln
```

3. **Запустите проект через Aspire AppHost (запускает все сервисы автоматически):**
```bash
cd BikeRentalPoint.AppHost

dotnet run
``` 
**AppHost автоматически запустит:**
- 🚀 API сервер (BikeRentalPoint.Api.Host)
- 🔄 Генератор данных (BikeRentalPoint.Generator.Kafka.Host)
- 🗄️ MySQL в Docker контейнере
- 📨 Apache Kafka в Docker контейнере

4. **После запуска откроются:**
   - **Aspire Dashboard** - `https://localhost:17259/` - панель мониторинга всех сервисов
   - **API Swagger** - `https://localhost:7168/swagger` - документация API
   - **Kafbat UI** - `http://localhost:65177/` - веб-интерфейс для управления Kafka (просмотр топиков, сообщений, консьюмеров)
   - **Generator API Swagger** - `https://localhost:7294/swagger` - документация API генератора данных

5. **В Aspire Dashboard вы увидите:**
   - 📊 Состояние всех сервисов (API, Generator, MySQL, Kafka)
   - 📈 Метрики и производительность
   - 🔍 Distributed tracing
   - 📝 Логи всех приложений в реальном времени
   - 🔗 Прямые ссылки на endpoints

## 📊 API Endpoints

API предоставляет полный набор CRUD операций и аналитические запросы через REST API:

### Аналитические endpoints (`/api/Analytics`)

1. **Горные велосипеды**
   - `GET /api/Analytics/mountain-bikes`
   - Получить все горные велосипеды
   - Возвращает: список горных велосипедов с характеристиками

2. **Топ моделей по прибыли**
   - `GET /api/Analytics/top-models/profit`
   - Получить топ-5 моделей велосипедов по прибыли от аренды
   - Возвращает: список моделей, отсортированных по общей прибыли

3. **Топ моделей по длительности**
   - `GET /api/Analytics/top-models/duration`
   - Получить топ-5 моделей велосипедов по общей длительности аренды
   - Возвращает: список моделей с суммарным временем использования

4. **Статистика аренды**
   - `GET /api/Analytics/rental-statistics`
   - Получить статистику по длительности аренды
   - Возвращает: средняя, минимальная и максимальная длительность аренды

5. **Лучшие арендаторы**
   - `GET /api/Analytics/top-renters`
   - Получить лучших арендаторов по количеству аренд
   - Возвращает: список арендаторов, отсортированных по количеству прокатов

6. **Длительность по типам**
   - `GET /api/Analytics/duration-by-type`
   - Получить общую длительность аренды, сгруппированную по типу велосипеда
   - Возвращает: статистику использования для каждого типа велосипеда

### CRUD операции

#### Велосипеды (`/api/Bikes`)

- `GET /api/Bikes` - Получить все велосипеды
  - Возвращает: список всех велосипедов в системе

- `POST /api/Bikes` - Создать новый велосипед
  - Body: данные нового велосипеда
  - Возвращает: созданный велосипед

- `GET /api/Bikes/{id}` - Получить велосипед по ID
  - Параметры: `id` (Guid) - уникальный идентификатор
  - Возвращает: детальную информацию о велосипеде

- `PUT /api/Bikes/{id}` - Обновить существующий велосипед
  - Параметры: `id` (Guid) - уникальный идентификатор
  - Body: обновленные данные велосипеда
  - Возвращает: обновленный велосипед

- `DELETE /api/Bikes/{id}` - Удалить велосипед
  - Параметры: `id` (Guid) - уникальный идентификатор
  - Возвращает: 204 No Content

- `GET /api/Bikes/{id}/model` - Получить информацию о модели велосипеда
  - Параметры: `id` (Guid) - уникальный идентификатор велосипеда
  - Возвращает: информацию о модели указанного велосипеда

#### Модели (`/api/Models`)

- `GET /api/Models` - Получить все модели велосипедов
  - Возвращает: список всех моделей велосипедов

- `POST /api/Models` - Создать новую модель велосипеда
  - Body: данные новой модели (название, тип, производитель)
  - Возвращает: созданную модель

- `GET /api/Models/{id}` - Получить модель по ID
  - Параметры: `id` (Guid) - уникальный идентификатор
  - Возвращает: детальную информацию о модели

- `PUT /api/Models/{id}` - Обновить существующую модель
  - Параметры: `id` (Guid) - уникальный идентификатор
  - Body: обновленные данные модели
  - Возвращает: обновленную модель

- `DELETE /api/Models/{id}` - Удалить модель
  - Параметры: `id` (Guid) - уникальный идентификатор
  - Возвращает: 204 No Content

#### Арендаторы (`/api/Renters`)

- `GET /api/Renters` - Получить всех арендаторов
  - Возвращает: список всех арендаторов

- `POST /api/Renters` - Создать нового арендатора
  - Body: данные нового арендатора (имя, контакты)
  - Возвращает: созданного арендатора

- `GET /api/Renters/{id}` - Получить арендатора по ID
  - Параметры: `id` (Guid) - уникальный идентификатор
  - Возвращает: детальную информацию об арендаторе

- `PUT /api/Renters/{id}` - Обновить существующего арендатора
  - Параметры: `id` (Guid) - уникальный идентификатор
  - Body: обновленные данные арендатора
  - Возвращает: обновленного арендатора

- `DELETE /api/Renters/{id}` - Удалить арендатора
  - Параметры: `id` (Guid) - уникальный идентификатор
  - Возвращает: 204 No Content

#### Аренды (`/api/Rents`)

- `GET /api/Rents` - Получить все аренды
  - Возвращает: список всех аренд

- `POST /api/Rents` - Создать новую аренду
  - Body: данные новой аренды (bikeId, renterId, даты)
  - Возвращает: созданную аренду

- `GET /api/Rents/{id}` - Получить аренду по ID
  - Параметры: `id` (Guid) - уникальный идентификатор
  - Возвращает: детальную информацию об аренде

- `PUT /api/Rents/{id}` - Обновить существующую аренду
  - Параметры: `id` (Guid) - уникальный идентификатор
  - Body: обновленные данные аренды
  - Возвращает: обновленную аренду

- `DELETE /api/Rents/{id}` - Удалить аренду
  - Параметры: `id` (Guid) - уникальный идентификатор
  - Возвращает: 204 No Content

- `GET /api/Rents/{id}/bike` - Получить информацию о велосипеде для аренды
  - Параметры: `id` (Guid) - уникальный идентификатор аренды
  - Возвращает: информацию о велосипеде, используемом в указанной аренде

- `GET /api/Rents/{id}/renter` - Получить информацию об арендаторе для аренды
  - Параметры: `id` (Guid) - уникальный идентификатор аренды
  - Возвращает: информацию об арендаторе указанной аренды

## 🧪 Тестирование

### Запуск всех тестов:
```bash
dotnet test BikeRentalPoint.sln
```


### Тестовое покрытие:
- **Unit Tests** - тестирование бизнес-логики и доменных моделей
- **Data Generation Tests** - проверка корректности генерации данных

## 📈 Особенности реализации

### Event-Driven Architecture с Kafka
- Асинхронная генерация данных через Kafka topics
- Retry-логика при сбоях подключения
- Consumer/Producer паттерн
- Гарантия доставки сообщений

### MySQL + EF Core
- Миграции для управления схемой БД
- Seed данные для начального заполнения
- Оптимизированные запросы с использованием LINQ
- Транзакционная целостность данных

### Observability через Aspire
- Централизованное логирование всех сервисов
- Distributed tracing для отслеживания запросов между компонентами
- Health checks для мониторинга работоспособности
- Метрики производительности в реальном времени
- Единая панель управления для всей инфраструктуры



## 🔄 CI/CD

Проект настроен на автоматическое тестирование через **GitHub Actions**:
- ✅ Автоматическая сборка при каждом push
- ✅ Запуск всех тестов
- ✅ Проверка code style и форматирования
- ✅ Анализ качества кода


## 👨‍💻 Разработка

Проект разработан в рамках курса **"Разработка корпоративных приложений"** с применением современных практик и паттернов промышленной разработки.

### Основные достижения:
- ✅ Чистая архитектура с разделением ответственности
- ✅ Микросервисная архитектура с .NET Aspire
- ✅ Тестируемый и поддерживаемый код
- ✅ SOLID принципы и best practices
- ✅ Асинхронная обработка событий
- ✅ Distributed observability
- ✅ Автоматизированное тестирование
- ✅ Документированное API

## 📄 Лицензия

Проект распространяется под лицензией MIT. Подробности в файле [LICENSE](LICENSE).

## 🤝 Контакты

**Разработчик:** [sk1fix](https://github.com/sk1fix)

**Курс:** Разработка корпоративных приложений
