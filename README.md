# Systemweb PDF API 服務

## 概述

這是一個基於 **開源 PDF 處理 API 服務**，遵循 **AGPLv3** 授權條款。本服務提供博暉科技的應用系統，可以透過此獨立的 API，處理 **PDF 分割、加密** 等功能。

## 功能

- 📄 **PDF 分割**：將 PDF 拆分為多個較小的 PDF 檔案。
- 🔒 **PDF 加密**：為 PDF 添加密碼保護。
- 📥 **上傳 & 處理**：上傳 PDF 進行處理。
- 📤 **下載處理後的 PDF**：獲取修改後的 PDF 檔案。

## 安裝與設定

### 先決條件

- **Visual Studio 2019**
- **.NET Framework 4.8**
- **iText 5（AGPL 版本）**
- **IIS（如需部署）**

### 克隆程式碼

```bash
git clone https://github.com/systemwebtw/PDFReportProcessor.git
cd PDFReportProcessor
```

### 使用 Visual Studio 2019 建置與執行

1. 開啟 **Visual Studio 2019**。
2. 點選 **[檔案] -> [開啟] -> [專案/方案]**，選擇 `ReportPDFProcessor.sln`。
3. 設定專案的 **目標框架為 .NET Framework 4.8**。
4. 按 **F5** 或點選 **執行**，啟動 API 服務。

### IIS 部署方式

1. **建置專案**：
   - 在 Visual Studio 內選擇 **發佈 -> 建置 Web 應用程式**
   - 選擇 **IIS 部署** 並產生對應的檔案
2. **設定 IIS**：
   - 在 Windows 上安裝 **IIS 角色**（若尚未安裝）
   - 在 IIS 建立新的站台，並將專案部署的 **發佈資料夾** 指向該站台
3. **設定應用程式集區**：
   - 設定 .NET Framework 版本為 4.8
4. **啟動應用程式**，並確保 API 可透過 `http://localhost:5000` 訪問

## API 端點

### 1️⃣ 分割 PDF

**端點:** `POST /api/pdf/split`

**請求:**

```json
{
  "file": "(上傳 PDF 檔案)",
  "splitAfterPages": [2, 5]
}
```

**回應:**

```json
{
  "message": "PDF 分割成功",
  "downloadUrls": ["/api/pdf/download/file1.pdf", "/api/pdf/download/file2.pdf"]
}
```

### 2️⃣ 加密 PDF

**端點:** `POST /api/pdf/encrypt`

**請求:**

```json
{
  "file": "(上傳 PDF 檔案)",
  "password": "secure123"
}
```

**回應:**

```json
{
  "message": "PDF 加密成功",
  "downloadUrl": "/api/pdf/download/encrypted.pdf"
}
```

## 部署方式

你可以使用以下方式部署此服務：

- **Windows Server / IIS 部署**
- **本機 Windows 環境執行**（適用於開發測試）

## 授權條款

本專案依據 **GNU Affero General Public License v3 (AGPLv3)** 授權發佈。任何對此專案的修改或整合，都必須符合 **AGPLv3** 的開源要求。

## 貢獻方式

歡迎貢獻！如果發現錯誤或有新功能需求，請提交 Pull Request 或建立 Issue。

## 聯絡方式

如有問題或需要支援，請至 GitHub 提出 Issue，或聯絡維護者 `services@systemweb.com.tw`。

---
