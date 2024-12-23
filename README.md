# ASP.NET Core

## Git Operations

### To clear your Git local cache:

````bash
git rm -r --cached .
git add .
git commit -am 'git cache cleared'
git push
````


## Git Commit Message Prefixes

- **feat**: New feature (e.g., `feat: add user login functionality`).
- **fix**: Bug fix (e.g., `fix: resolve issue with user login`).
- **chore**: Maintenance tasks (e.g., `chore: update dependencies`).
- **docs**: Documentation changes (e.g., `docs: update README`).
- **style**: Code formatting changes (e.g., `style: format code`).
- **refactor**: Code refactoring (e.g., `refactor: streamline user flow`).
- **perf**: Performance improvements (e.g., `perf: optimize dashboard load`).
- **test**: Adding or updating tests (e.g., `test: add unit tests for login`).
- **build**: Build system changes (e.g., `build: update webpack`).
- **ci**: CI configuration changes (e.g., `ci: add GitHub Actions`).
- **revert**: Reverting previous commits (e.g., `revert: revert commit abc1234`).
- **merge**: Merging branches (e.g., `merge: merge branch 'feature-branch'`).
- **hotfix**: Quick fixes for critical issues (e.g., `hotfix: correct typo`).

### Example Commit Messages

- `feat: add search functionality to navbar`
- `fix: resolve issue with login validation`


### Scafford EFCore Database First

```bash
Scaffold-DbContext "Server=.;Database=DotNetTesting;User ID=sa;Password=root;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context AppDbContext
```
Alternate command:
```bash
dotnet ef dbcontext scaffold "Server=.;Database=DotNetTesting;User ID=sa;Password=root;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext -f
```
