# 🧩 API Endpoint Documentation Instructions (Final Template)

## 🧠 General Rules
- **Language:** English  
- **Font:** Calibri (Body)  
- **Text Direction:** Left-to-Right (LTR)  
- **Delimiters:** Always bold (e.g., `**Path:**`, `**ID:**`, `**HTTP Method:**`)  
- **No empty pages or line breaks** between sections.  
- **Table headers bolded**, cell padding consistent.  
- Maintain **consistent indentation** for all text lines.  
- Always keep **Path and ID** on one line.  

**Example:**
```
Path: HMIS_BackOffice > Finance > AccountAssignmentController > SaveAccountAssignment  
ID: 48343744810100764
```

---

## 🧾 Section Order

### 1️⃣ Path & ID
```
Path: HMIS_BackOffice > [Module] > [Controller] > [Endpoint]
ID: [Endpoint ID]
```

---

### 2️⃣ Endpoint Summary
- A short, clear explanation of what the endpoint does.  
- Mention its purpose, controller inheritance, and any main managers used.  
- Include context about input/output models and purpose.

---

### 3️⃣ Endpoint Overview

| **Field** | **Description** |
|:--|:--|
| **HTTP Method:** | GET / POST / PUT / DELETE (single line only) |
| **Parameters:** | List all parameters with their data types |
| **Return Type:** | Specify the model, IQueryable, or ActionResult |
| **Controller Base:** | Example: `BaseApiController` or `BaseODataController` |
| **Repository / Managers Used:** | Mention all key managers or repositories involved |

---

### 4️⃣ Observed Patterns / Warnings
- Analyze if endpoint uses **DTC**, **TransactionScope**, **Temporal**, or **OData**.
- **If DTC detected:**  
  > Recommendation: Replace DTC with Temporal Transactions to reduce overhead.  
- **If DTC = No:**  
  > Write only “No”, without further notes.  
- **If Messaging Queue used:**  
  > Keep section and add optimization recommendations.  
- **If no Messaging Queue:**  
  > Omit the section entirely.

---

### 5️⃣ Functionality Testing

| **Aspect** | **Test Case / Input** | **Expected Result** | **Notes / Recommendations** |
|:--|:--|:--|:--|
| Null Input | — | — | — |
| Valid Data | — | — | — |
| Error Handling | — | — | — |

Include OData filters, `$top`, `$skip`, `$orderby`, and concurrency checks.

---

### 6️⃣ Business Validity
- Validate against finance or business rules.
- Check for data consistency and referential integrity.
- Mention any specific accounting logic (if applicable).

---

### 7️⃣ Performance Evaluation
- Evaluate **EF queries**, **Joins**, and **OData expressions**.  
- Look for performance bottlenecks and indexing issues.  
- Suggest caching or async refactoring if needed.  

---

### 8️⃣ Security Assessment
- Ensure endpoint is decorated with `[Authorize]`.  
- Check that sensitive fields are not exposed.  
- Mention role-based access control if relevant.  

---

### 9️⃣ Overall Recommendations & Action Items
Include architectural and design-level advice such as:

- ✅ Apply **CQRS pattern** for clear command/query segregation.  
- ✅ Implement **IOptions pattern** for configuration injection.  
- ✅ Use **Clean Code principles** — SRP, short methods, consistent naming.  
- ✅ Choose **any suitable design pattern** based on the problem; **don’t force a pattern**.  
  - Examples to consider (pick what fits): **Factory**, **Repository**, **Mediator**, **Strategy**, **Specification**, **Template Method**, **Decorator**, **Adapter**, **Facade**, **Builder**, **Observer**, **Null Object**, **Pipeline**, **Chain of Responsibility**, **Unit of Work**, **Aggregate Root**, **Domain Events**.  
- ✅ Improve performance via caching, DTOs, pagination.  
- ✅ Apply async/await for I/O-bound EF calls.  
- ✅ Document all endpoint dependencies and service flows clearly.  

> **Pattern selection rule of thumb:** Start from the problem constraints (variability, lifecycle, composition, orchestration). Prefer simplest option; add patterns incrementally when you hit real complexity.

---

### 🧾 Notes for Export
- Final files exported as:  
  `NNN_BackOffice-[Module]_[EndpointID].docx`
- Ensure each section follows the same indentation and visual consistency.  
- No page breaks inside tables or between section titles.

---

© 2025 HMIS_BackOffice Technical Documentation Framework
