# Todo.Core — библиотека Todo + CI/анализаторы

Репозиторий сделан под практическое занятие **«Автоматизация сборки и статический анализ кода»**: решение с библиотекой, примером использования, тестами, анализаторами и CI в GitHub Actions. fileciteturn0file0

## Структура

```
Todo.sln
.editorconfig.base
.editorconfig.strict
src/
  Todo.Core/
  Todo.SampleApp/
tests/
  Todo.Core.Tests/
.github/
  workflows/
    ci-analysis.yml
```

## Требования

- Windows 10/11
- **.NET SDK 8.0+**
- Git

## Сборка и тесты (Windows PowerShell)

```powershell
dotnet restore
dotnet build -c Release
dotnet test -c Release
```

## Запуск примера

```powershell
dotnet run --project .\src\Todo.SampleApp\Todo.SampleApp.csproj -c Release
```

## Локальный запуск анализа (base/strict)

> В методичке предлагается переключать набор правил копированием нужного файла в `.editorconfig`. fileciteturn0file0

**Base (мягкий режим):**
```powershell
Copy-Item .\.editorconfig.base .\.editorconfig -Force
dotnet build -c Release
```

**Strict (жёсткий режим):**
```powershell
Copy-Item .\.editorconfig.strict .\.editorconfig -Force
dotnet build -c Release
```

## Установка как NuGet-пакета (через GitHub Packages) — Windows

Ниже — инструкция для случая, когда ты **опубликовал(а)** пакет `Todo.Core` в **GitHub Packages** (NuGet feed).

### 1) Создай Personal Access Token (PAT)

В GitHub создай токен с правами:
- `read:packages` (для установки)
- `write:packages` (для публикации)
- `repo` (часто нужен для приватных репо)

### 2) Добавь источник пакетов (GitHub Packages)

Подставь:
- `<OWNER>` — владелец репозитория (ник/организация)
- `<USERNAME>` — твой GitHub логин
- `<TOKEN>` — PAT

```powershell
dotnet nuget add source "https://nuget.pkg.github.com/<OWNER>/index.json" `
  --name "github" `
  --username "<USERNAME>" `
  --password "<TOKEN>" `
  --store-password-in-clear-text
```

Проверить источники:
```powershell
dotnet nuget list source
```

### 3) Установи пакет в другой проект

```powershell
dotnet add package Todo.Core --version 1.0.0 --source "github"
```

## Как собрать `.nupkg` локально

```powershell
dotnet pack .\src\Todo.Core\Todo.Core.csproj -c Release -o .\artifacts
```

В результате появится файл:
```
artifacts\Todo.Core.1.0.0.nupkg
```

## Публикация в GitHub Packages (ручная)

```powershell
dotnet nuget push .\artifacts\Todo.Core.1.0.0.nupkg `
  --api-key "<TOKEN>" `
  --source "https://nuget.pkg.github.com/<OWNER>/index.json"
```

## Быстрый пример использования (C#)

```csharp
using Todo.Core;

var list = new TodoList();
list.Add("проснуться");
list.Add("выпить воды");

foreach (var item in list.Items)
{
    Console.WriteLine(item.Title);
}
```
