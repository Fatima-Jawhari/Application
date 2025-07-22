# Dynamic Homepage System

## Overview
The homepage has been converted from static HTML to a fully dynamic, data-driven system using ASP.NET Core, Entity Framework, and a clean architecture pattern.

## Architecture

### 1. **Core Layer** (`MyApp.Core`)
- **Models**: `HomePageContent.cs` - DTOs for homepage sections
- **Database Entities**: `HomePageContentEntity.cs` - EF entities for database storage
- **Interfaces**: `IHomePageService.cs` - Service contract

### 2. **Application Layer** (`MyApp1.Application`)
- **HomePageService**: In-memory implementation with default content
- **DatabaseHomePageService**: Database-backed implementation with full CRUD operations

### 3. **Web Layer** (`MyApp1.Web`)
- **Index.cshtml**: Dynamic Razor page using model data
- **Index.cshtml.cs**: Page model with dependency injection
- **Admin/HomeContent.cshtml**: Admin interface for content management

## Features

### ✅ **Dynamic Content Rendering**
- Hero section with customizable title, subtitle, CTA, and stats
- Feature cards with icons, descriptions, and links
- Testimonials with author information
- Upcoming events with dates and locations
- All section headers are configurable

### ✅ **Admin Interface**
- Navigate to `/Admin/HomeContent` to manage content
- Edit hero section content
- Modify statistics
- Update section titles and descriptions
- Real-time form validation

### ✅ **Database Integration**
- Entity Framework models for persistent storage
- Automatic mapping between DTOs and entities
- Supports versioning and audit trails

### ✅ **Service Architecture**
- Interface-based design for easy testing
- Two implementations: in-memory and database-backed
- Dependency injection configured in Program.cs

## Usage

### **Viewing the Homepage**
Visit `/` to see the dynamic homepage with current content.

### **Managing Content**
1. Navigate to `/Admin/HomeContent`
2. Modify any field in the form
3. Click "Save Changes"
4. View the updated homepage

### **Switching Between Services**

**For In-Memory Service (default):**
```csharp
// In Program.cs
builder.Services.AddScoped<IHomePageService, HomePageService>();
```

**For Database Service:**
```csharp
// In Program.cs  
builder.Services.AddScoped<IHomePageService, DatabaseHomePageService>();
```

## Database Schema

The system creates the following tables:
- `HomePageContents` - Main content settings
- `StatItems` - Homepage statistics
- `FeatureCards` - Feature section cards
- `TestimonialCards` - Customer testimonials
- `EventCards` - Upcoming events

## Benefits

1. **Content Management**: Non-technical users can update content
2. **Maintainability**: Clean separation of concerns
3. **Scalability**: Easy to add new sections or content types
4. **Testability**: Interface-based design enables unit testing
5. **Flexibility**: Switch between storage mechanisms easily

## Future Enhancements

- **Multi-language support**: Localized content
- **Image upload**: Direct image management
- **Content scheduling**: Publish content at specific times
- **A/B testing**: Test different content variations
- **API endpoints**: Headless CMS capabilities
- **Caching**: Redis/memory caching for performance

## Development Notes

- Default content is provided if no database content exists
- The system gracefully falls back to default values
- All database operations are async for better performance
- Entity relationships are properly configured with foreign keys