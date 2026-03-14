import psycopg2
from faker import Faker
import datetime

connection = psycopg2.connect(
    host="localhost",
    database="WikiDb",
    user="postgres",
    password="yourpassword",
    port="5432"
)

cursor = connection.cursor()
faker = Faker()

def generate_markdown_description():
    description = f"# {faker.sentence(nb_words=4)}\n\n"
    
    description += faker.paragraph(nb_sentences=3) + "\n\n"
    description += faker.paragraph(nb_sentences=2) + "\n\n"
    description += "## Key Points\n\n"
    
    for _ in range(3):
        description += f"- {faker.sentence()}\n"
        
    description += "\n"
    description += f"**Note:** {faker.sentence()}\n\n"
    description += f"```\n{faker.text(max_nb_chars=100)}\n```\n"

    return description

    

def seed_wiki_pages(count=32):
    print(f"Seeding {count} wiki pages...")
    for _ in range(count):
        title = faker.sentence(nb_words=3)
        description = generate_markdown_description()
        created_at = datetime.datetime.now(datetime.timezone.utc)
        
        cursor.execute(
            'INSERT INTO "WikiPages" ("Title", "Content", "CreatedAt") VALUES (%s, %s, %s)',
            (title, description, created_at)
        )
        
    connection.commit()
    print(f"Successfully seeded {count} wiki pages.")


if __name__ == "__main__":
    seed_wiki_pages()
        
