from fastapi import FastAPI
from pydantic import BaseModel
from datetime import datetime
from typing import List
import logging

logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

app = FastAPI()

class Message(BaseModel):
    username: str
    text: str

messages: List[Message] = []

@app.post("/chat/send-message/")
async def send_message(message: Message):
    """
    Receive a message and add it to the chat history.

    :param Message message: A message containing a username and text.

    :return dict: A confirmation message.
    """
    timestamp = datetime.now().strftime("%Y-%m-%d %H:%M:%S")
    logger.info(f"[{timestamp}] {message.username}: {message.text}")
    messages.append(message)
    return {"message": "Message received"}

@app.get("/chat/get-messages/")
async def get_messages():
    """
    Returns the chat history.

    :return List[Message]: A list of messages.
    """
    return messages

if __name__ == "__main__":
    import uvicorn
    uvicorn.run(app, host="localhost", port=1337)
