// Interactive Elements for AmetCoin About Page
// Smooth scrolling navigation
document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        e.preventDefault();
        document.querySelector(this.getAttribute('href')).scrollIntoView({
            behavior: 'smooth'
        });
    });
});

// Animated counters for statistics
function animateCounter(element, start, end, duration) {
    let startTime = null;
    const increment = (end - start) / (duration / 16);

    const updateCounter = () => {
        if (!startTime) startTime = performance.now();
        const elapsed = performance.now() - startTime;
        const progress = Math.min(elapsed / duration, 1);

        const currentValue = Math.floor(start + increment * progress);
        element.textContent = currentValue.toLocaleString();

        if (progress < 1) {
            requestAnimationFrame(updateCounter);
        }
    };

    requestAnimationFrame(updateCounter);
}

// Initialize counters when they come into view
const counters = document.querySelectorAll('.counter');
const observerOptions = {
    threshold: 0.5,
    rootMargin: '0px 0px -50px 0px'
};

const counterObserver = new IntersectionObserver((entries) => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            const counter = entry.target;
            const endValue = parseInt(counter.getAttribute('data-target'));
            animateCounter(counter, 0, endValue, 2000);
            counterObserver.unobserve(counter);
        }
    });
}, observerOptions);

counters.forEach(counter => counterObserver.observe(counter));

// FAQ Accordion
const faqItems = document.querySelectorAll('.faq-item');
faqItems.forEach(item => {
    const question = item.querySelector('.faq-question');
    question.addEventListener('click', () => {
        const answer = item.querySelector('.faq-answer');
        const isActive = item.classList.contains('active');

        // Close all items
        faqItems.forEach(i => i.classList.remove('active'));

        // Open clicked item if it wasn't active
        if (!isActive) {
            item.classList.add('active');
        }
    });
});

// Testimonial Carousel
class TestimonialCarousel {
    constructor(container) {
        this.container = container;
        this.slides = container.querySelectorAll('.testimonial-slide');
        this.currentIndex = 0;
        this.slideInterval = null;
        this.init();
    }

    init() {
        this.updateSlide();
        this.startAutoPlay();
        this.setupNavigation();
    }

    updateSlide() {
        this.slides.forEach((slide, index) => {
            slide.style.display = index === this.currentIndex ? 'block' : 'none';
        });
    }

    nextSlide() {
        this.currentIndex = (this.currentIndex + 1) % this.slides.length;
        this.updateSlide();
    }

    startAutoPlay() {
        this.slideInterval = setInterval(() => {
            this.nextSlide();
        }, 5000);
    }

    setupNavigation() {
        const prevBtn = this.container.querySelector('.carousel-prev');
        const nextBtn = this.container.querySelector('.carousel-next');

        if (prevBtn) {
            prevBtn.addEventListener('click', () => {
                this.currentIndex = (this.currentIndex - 1 + this.slides.length) % this.slides.length;
                this.updateSlide();
            });
        }

        if (nextBtn) {
            nextBtn.addEventListener('click', () => {
                this.nextSlide();
            });
        }
    }
}

// Initialize carousel if it exists
document.addEventListener('DOMContentLoaded', () => {
    const carouselContainer = document.querySelector('.testimonials-carousel');
    if (carouselContainer) {
        new TestimonialCarousel(carouselContainer);
    }
});

// Form Validation
const contactForm = document.getElementById('contact-form');
if (contactForm) {
    contactForm.addEventListener('submit', function(e) {
        e.preventDefault();
        const formData = new FormData(contactForm);
        const isValid = validateForm(formData);

        if (isValid) {
            // In a real application, you would submit the form here
            alert('Thank you for your message! We will get back to you soon.');
            contactForm.reset();
        }
    });
}

function validateForm(formData) {
    let isValid = true;
    const errors = {};

    // Validate name
    const name = formData.get('name');
    if (!name || name.trim().length < 2) {
        isValid = false;
        errors.name = 'Name must be at least 2 characters long';
    }

    // Validate email
    const email = formData.get('email');
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!email || !emailRegex.test(email)) {
        isValid = false;
        errors.email = 'Please enter a valid email address';
    }

    // Validate message
    const message = formData.get('message');
    if (!message || message.trim().length < 10) {
        isValid = false;
        errors.message = 'Message must be at least 10 characters long';
    }

    // Clear previous errors
    document.querySelectorAll('.error-message').forEach(el => el.textContent = '');

    // Show errors if any
    if (!isValid) {
        Object.keys(errors).forEach(field => {
            const errorElement = document.getElementById(`${field}-error`);
            if (errorElement) {
                errorElement.textContent = errors[field];
            }
        });
    }

    return isValid;
}

// Live Market Price Display
function updateMarketPrice() {
    const priceElement = document.getElementById('live-price');
    if (priceElement) {
        // Simulate price updates
        const basePrice = 0.00000001; // Base price in BTC
        const fluctuation = (Math.random() - 0.5) * 0.000000005; // Random fluctuation
        const currentPrice = basePrice + fluctuation;

        priceElement.textContent = currentPrice.toFixed(10);
    }
}

// Update price every 5 seconds
setInterval(updateMarketPrice, 5000);
updateMarketPrice(); // Initial update

// Keyboard accessibility for interactive elements
document.addEventListener('keydown', function(e) {
    if (e.key === 'Enter' || e.key === ' ') {
        const focusedElement = document.activeElement;
        if (focusedElement.classList.contains('faq-question')) {
            focusedElement.click();
        }
    }
});