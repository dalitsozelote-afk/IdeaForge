
from fastapi import FastAPI

app = FastAPI(
    title="IdeaForge AI Service",
    description="AI engine for analysing invention ideas",
    version="1.0.0"
)

@app.get("/")
def home():
    return {
        "message": "Welcome to IdeaForge AI Service!",
        "status": "Running"
    }
